namespace WebPlex.Applications.CompactStore.Mvc {
    using System.Web.Mvc;
    using WebPlex.Applications.CompactStore.Data.Repositories;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Security;

    public abstract class StoreViewPage<T> : WebViewPage<T> {
        public override void InitHelpers() {
            base.InitHelpers();

            var routeValues = ViewContext.RouteData.Values;

            if (routeValues.ContainsKey("CategorySlug") && routeValues["CategorySlug"] != null) {
                var categoryRepository = DependencyResolver.Current.GetService<ICategoryRepository>();
                CurrentCategory = categoryRepository.GetBySlug(routeValues["CategorySlug"].ToString());
            }

            if (ViewContext.RouteData.Values.ContainsKey("Order"))
                CurrentSortOrder = new UrlToken<SortOrder>(ViewContext.RouteData.Values["Order"]);

            if (ViewContext.RouteData.Values.ContainsKey("Direction"))
                CurrentSortDirection = new UrlToken<SortDirection>(ViewContext.RouteData.Values["Direction"]);

            var cartItemRepository = DependencyResolver.Current.GetService<ICartItemRepository>();
            CartItemsCount = cartItemRepository.GetItemsCount();

            if (CustomerContext.Current.IsAuthenticated) {
                var orderRepository = DependencyResolver.Current.GetService<IOrderRepository>();
                OrdersCount = orderRepository.GetCountByCustomer(CustomerContext.Current.Customer);
            }
        }

        protected string ReturnUrl {
            get { return ViewBag.ReturnUrl; }
        }

        protected int CartItemsCount {
            get { return (int) Context.Items["CartItemsCount"]; }
            private set { Context.Items["CartItemsCount"] = value; }
        }

        protected int OrdersCount {
            get { return (int) Context.Items["OrdersCount"]; }
            private set { Context.Items["OrdersCount"] = value; }
        }

        protected CategoryModel CurrentCategory {
            get { return (CategoryModel) Context.Items["CurrentCategory"]; }
            private set { Context.Items["CurrentCategory"] = value; }
        }

        protected SortOrder? CurrentSortOrder {
            get { return (SortOrder?) Context.Items["CurrentSortOrder"]; }
            private set { Context.Items["CurrentSortOrder"] = value; }
        }

        protected SortDirection? CurrentSortDirection {
            get { return (SortDirection?) Context.Items["CurrentSortDirection"]; }
            private set { Context.Items["CurrentSortDirection"] = value; }
        }
    }
}
