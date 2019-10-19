using MvcMailMessage = Mvc.Mailer.MvcMailMessage;

namespace WebPlex.Applications.CompactStore.Controllers {
    using System.Collections.Generic;
    using T4MVC;
    using WebPlex.Applications.CompactStore.Extensions;
    using WebPlex.Applications.CompactStore.Messaging;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Properties;
    using WebPlex.Applications.CompactStore.ViewModels;

    public class NotificationController : StoreMailerBase {
        public virtual MvcMailMessage PasswordResetRequested(CustomerModel customer) {
            ViewData.Model = customer;

            AfeMessagingHelpers.SendMessage(customer.CellPhone, Resources.Views_Notification_PasswordResetRequested_Message, customer.GetDisplayName());

            return Populate(message => {
                message.ViewName = Views.Notification.PasswordResetRequested_cshtml;
                message.Subject = Resources.Views_Notification_PasswordResetRequested_Subject;
                message.To.Add(customer.Email);
            });
        }

        public virtual MvcMailMessage PasswordReset(CustomerModel customer) {
            ViewData.Model = customer;

            AfeMessagingHelpers.SendMessage(customer.CellPhone, Resources.Views_Notification_PasswordReset_Message, customer.GetDisplayName());

            return Populate(message => {
                message.ViewName = Views.Notification.PasswordReset_cshtml;
                message.Subject = Resources.Views_Notification_PasswordReset_Subject;
                message.To.Add(customer.Email);
            });
        }

        public virtual MvcMailMessage OrderSubmitted(CustomerModel customer, OrderModel order, IEnumerable<OrderLineModel> orderLines) {
            ViewData.Model = new OrderSubmittedViewModel {
                Customer = customer,
                Order = order,
                OrderLines = orderLines
            };

            AfeMessagingHelpers.SendMessage(customer.CellPhone, Resources.Views_Notification_OrderSubmitted_Message, customer.GetDisplayName(), order.AccessToken);

            return Populate(message => {
                message.ViewName = Views.Notification.OrderSubmitted_cshtml;
                message.Subject = Resources.Views_Notification_OrderSubmitted_Subject;
                message.To.Add(customer.Email);
            });
        }
    }
}
