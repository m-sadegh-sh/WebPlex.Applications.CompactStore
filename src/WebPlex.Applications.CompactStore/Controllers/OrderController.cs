namespace WebPlex.Applications.CompactStore.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Extensions;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Mvc;
    using WebPlex.Applications.CompactStore.Properties;
    using WebPlex.Applications.CompactStore.Security;
    using WebPlex.Applications.CompactStore.ViewModels;

    public partial class OrderController : StoreController {
        private readonly IProductRepository _productRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderLineRepository _orderLineRepository;
        private readonly IOrderComplaintRepository _orderComplaintRepository;
        private readonly NotificationController _notificationController;

        public OrderController(IProductRepository productRepository, ICartItemRepository cartItemRepository, IOrderRepository orderRepository, IOrderLineRepository orderLineRepository, IOrderComplaintRepository orderComplaintRepository, NotificationController notificationController) {
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            _orderRepository = orderRepository;
            _orderLineRepository = orderLineRepository;
            _orderComplaintRepository = orderComplaintRepository;
            _notificationController = notificationController;
        }

        [HttpPost]
        public virtual ActionResult ValidateAccessToken(string accessToken) {
            var order = _orderRepository.GetByAccessToken(accessToken);

            var isValid = order != null;

            return Json(isValid);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public virtual ActionResult Submit() {
            string returnUrl;

            if (!_cartItemRepository.GetAll().Any()) {
                returnUrl = Url.Action(MVC.Home.Root());

                return RedirectedAsync(returnUrl, Resources.Error_CartIsEmpty, true);
            }

            if (!CustomerContext.Current.IsAuthenticated) {
                returnUrl = Url.Action(MVC.Account.Login(Url.Action(MVC.Order.Submit())));

                return RedirectedAsync(returnUrl, Resources.Error_LoginRequired, true);
            }

            var order = new OrderModel {
                AccessToken = SecurityHelpers.GenerateToken(8),
                Customer = CustomerContext.Current.Customer,
                SubmitDateUtc = DateTime.UtcNow,
                Status = OrderStatus.Submitted,
                IpAddress = Request.UserHostAddress
            };

            _orderRepository.AddOrUpdate(order);
            _orderRepository.SaveChanges();

            var cartItems = _cartItemRepository.GetAll();
            var orderLines = new List<OrderLineModel>();
            var products = _productRepository.GetAllByIds(cartItems.Select(cim => cim.Id).ToArray());

            foreach (var cartItem in _cartItemRepository.GetAll()) {
                var product = products[cartItem.Id];

                var orderLine = new OrderLineModel {
                    Order = order,
                    Product = product,
                    Count = cartItem.Count
                };

                _orderLineRepository.AddOrUpdate(orderLine);
                orderLines.Add(orderLine);

                order.TotalPrice += cartItem.TotalPrice;
            }

            _orderLineRepository.SaveChanges();
            _orderRepository.SaveChanges();

            _cartItemRepository.DeleteAll();
            _cartItemRepository.SaveChanges();

            _notificationController.OrderSubmitted(CustomerContext.Current.Customer, order, orderLines).Send();

            returnUrl = Url.Action(MVC.Order.CheckOut(order.AccessToken));

            return RedirectedAsync(returnUrl, Resources.Success_OrderSubmitted);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [CustomerAuthorized]
        [AdminRequired]
        public virtual ActionResult List(int? page, int? size) {
            int totalItemsCount;
            var orders = _orderRepository.GetByCustomer(CustomerContext.Current.Customer, ref page, ref size, out totalItemsCount);

            var viewModel = new OrderListViewModel(orders) {
                Page = page.GetValueOrDefault(),
                Size = size.GetValueOrDefault(),
                TotalItemsCount = totalItemsCount
            };

            return ViewAsync(Views.List, Views._List, viewModel);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [CustomerAuthorized]
        public virtual ActionResult Cancel(string accessToken, string returnUrl) {
            var order = _orderRepository.GetByAccessToken(accessToken);

            if (order == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Order);

            if (!order.Status.IsCancellable())
                return RedirectedAsync(returnUrl, Resources.Error_Order_NotCancellable, true);

            order.Status = OrderStatus.Cancelled;

            _orderRepository.AddOrUpdate(order);
            _orderRepository.SaveChanges();

            return RedirectedAsync(returnUrl, Resources.Success_OrderCancelled);
        }

        [HttpGet]
        [CustomerAuthorized]
        public virtual ActionResult CheckOut(string accessToken) {
            var order = _orderRepository.GetByAccessToken(accessToken);

            if (order == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Order);

            if (!order.Status.IsCheckOutRequired())
                return FailedAsync(Views.CheckOut, Views._CheckOut, null, Resources.Error_Order_AlreadyCheckedOut);

            if (_orderRepository.IsTrustedCustomer(CustomerContext.Current.Customer, order)) {
                var viewModel = new CheckOutViewModel {
                    Order = order,
                    CheckOutType = order.Status == OrderStatus.PayOnDemand ? CheckOutType.PayOnDemand : CheckOutType.OnlinePayment
                };

                return ViewAsync(Views.CheckOut, Views._CheckOut, viewModel);
            }

            var returnUrl = Url.Action(MVC.Order.PreparePaymentRequest(order.AccessToken));

            return RedirectedAsync(returnUrl, Resources.Success_PreparingPaymentRequest);
        }

        [HttpPost]
        [CustomerAuthorized]
        public virtual ActionResult CheckOut(CheckOutViewModel model) {
            string returnUrl;

            var order = _orderRepository.GetByAccessToken(model.Order.AccessToken);

            if (order == null)
                throw new HttpException((int) HttpStatusCode.NotFound, Resources.Error_NotFound_Order);

            if (model.CheckOutType == CheckOutType.PayOnDemand) {
                order.Status = OrderStatus.PayOnDemand;

                _orderRepository.AddOrUpdate(order);
                _orderRepository.SaveChanges();

                returnUrl = Url.Action(MVC.Order.List());

                return RedirectedAsync(returnUrl, Resources.Success_ReturingToOrdersList);
            }

            returnUrl = Url.Action(MVC.Order.PreparePaymentRequest(order.AccessToken));

            return RedirectedAsync(returnUrl, Resources.Success_PreparingPaymentRequest);
        }

        [HttpGet]
        [CustomerAuthorized]
        public virtual ActionResult PreparePaymentRequest(string accessToken) {
            var returnUrl = Url.Action(MVC.Order.List());

            return RedirectedAsync(returnUrl, Resources.Error_NotImplementedYet, true);
        }

        [HttpGet]
        [CustomerAuthorized]
        public virtual ActionResult Track(string accessToken) {
            var model = new TrackViewModel();

            if (!string.IsNullOrEmpty(accessToken)) {
                model.Order = _orderRepository.GetByAccessToken(accessToken);

                if (model.Order == null)
                    return FailedAsync(Views.Track, Views._Track, model, Resources.Error_NotFound_Order);

                model.SubmittedComplaint = _orderComplaintRepository.GetByOrder(model.Order);

                if (model.SubmittedComplaint == null) {
                    model.SubmittedComplaint = new OrderComplaintModel {
                        Order = model.Order,
                        Priority = ComplaintPriority.Normal
                    };
                }
            }

            return ViewAsync(Views.Track, Views._Track, model);
        }

        [HttpPost]
        [CustomerAuthorized]
        public virtual ActionResult Track(TrackViewModel model) {
            ModelState["SubmittedComplaint.Order"].Errors.Clear();

            var order = _orderRepository.GetByAccessToken(model.AccessToken);

            if (order == null)
                return FailedAsync(Views.Track, Views._Track, null, Resources.Error_NotFound_Order);

            model.Order = order;

            if (model.ComplaintIsNew) {
                model.SubmittedComplaint.Order = order;
                model.SubmittedComplaint.SubmitDateUtc = DateTime.UtcNow;
                model.SubmittedComplaint.Status = ComplaintStatus.Pending;

                _orderComplaintRepository.AddOrUpdate(model.SubmittedComplaint);
                _orderComplaintRepository.SaveChanges();

                return SucceededAsync(Views.Track, Views._Track, model, Resources.Success_OrderComplaintSubmitted);
            }

            if (model.ComplaintIsUpdated) {
                var dbOrderComplaint = _orderComplaintRepository.GetByOrder(order);
                dbOrderComplaint.Message = model.SubmittedComplaint.Message;
                dbOrderComplaint.Priority = model.SubmittedComplaint.Priority;

                _orderComplaintRepository.AddOrUpdate(dbOrderComplaint);
                _orderComplaintRepository.SaveChanges();

                model.SubmittedComplaint = dbOrderComplaint;

                return SucceededAsync(Views.Track, Views._Track, model, Resources.Success_OrderComplaintUpdated);
            }

            model.SubmittedComplaint = _orderComplaintRepository.GetByOrder(order);

            if (model.SubmittedComplaint == null) {
                model.SubmittedComplaint = new OrderComplaintModel {
                    Order = order,
                    Priority = ComplaintPriority.Normal
                };
            }

            return ViewAsync(Views.Track, Views._Track, model);
        }
    }
}
