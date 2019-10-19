using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (RouteRegisterar), "RegisterRoutes")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using System.Net;
    using System.Web.Mvc;
    using System.Web.Mvc.Routing.Constraints;
    using System.Web.Routing;
    using WebPlex.Applications.CompactStore.Models;
    using WebPlex.Applications.CompactStore.Mvc;
    using WebPlex.Applications.CompactStore.Routing;

    public static class RouteRegisterar {
        public static void RegisterRoutes() {
            var routes = RouteTable.Routes;

            routes.LowercaseUrls = true;
            routes.AppendTrailingSlash = false;
            routes.RouteExistingFiles = false;

            routes.MapRoute("Optimization-Image", "{MaximumWidth}x{MaximumHeight}/{*RelativeUrl}", MVC.Optimization.Image(), null, new {
                MaximumWidth = new IntRouteConstraint(),
                MaximumHeight = new IntRouteConstraint()
            });

            routes.MapRoute("Account-ValidateCustomerCellPhone", "Accounts/Validate-Customer-CellPhone.wplx", MVC.Account.ValidateCustomerCellPhone(), new {
                Freeness = false
            });

            routes.MapRoute("Account-ValidateCustomerCellPhone-Freeness", "Accounts/Validate-Customer-CellPhone-Freeness.wplx", MVC.Account.ValidateCustomerCellPhone(), new {
                Freeness = true
            });

            routes.MapRoute("Account-ValidateCustomerEmail", "Accounts/Validate-Customer-Email.wplx", MVC.Account.ValidateCustomerEmail(), new {
                Freeness = false
            });

            routes.MapRoute("Account-ValidateCustomerEmail-Freeness", "Accounts/Validate-Customer-Email-Freeness.wplx", MVC.Account.ValidateCustomerEmail(), new {
                Freeness = true
            });

            routes.MapRoute("Account-Register", "Accounts/Register.wplx", MVC.Account.Register());

            routes.MapRoute("Account-ResetPassword", "Accounts/Reset-Password.wplx", MVC.Account.ResetPassword());

            routes.MapRoute("Account-ResetPasswordCallback", "Accounts/Reset-Password/{ResetPasswordToken}/Callback.wplx", MVC.Account.ResetPasswordCallback(), null, new {
                ResetPasswordToken = new SlugRouteConstraint()
            });

            routes.MapRoute("Account-Login", "Accounts/Login.wplx", MVC.Account.Login());

            routes.MapRoute("Account-UpdateProfile", "Accounts/Update-Profile.wplx", MVC.Account.UpdateProfile());

            routes.MapRoute("Account-ChangePassword", "Accounts/Change-Password.wplx", MVC.Account.ChangePassword());

            routes.MapRoute("Account-Logout", "Accounts/Logout.wplx", MVC.Account.Logout());

            routes.MapRoute("Cart-Form", "Cart/Form.wplx", MVC.Cart.Form());

            routes.MapRoute("Cart-Add", "Cart/Items/{Id}/Add.wplx", MVC.Cart.Add(), null, new {
                Id = new IntRouteConstraint()
            });

            routes.MapRoute("Cart-Remove", "Cart/Items/{Id}/Remove.wplx", MVC.Cart.Remove(), new {
                RemoveAll = false
            }, new {
                Id = new IntRouteConstraint()
            });

            routes.MapRoute("Cart-RemoveAll", "Cart/Items/{Id}/Remove-All.wplx", MVC.Cart.Remove(), new {
                RemoveAll = true
            }, new {
                Id = new IntRouteConstraint()
            });

            routes.MapRoute("Order-ValidateAccessToken", "Orders/Validate-Access-Token.wplx", MVC.Order.ValidateAccessToken());

            routes.MapRoute("Order-List", "Orders/List.wplx", MVC.Order.List());

            routes.MapRoute("Order-Cancel", "Orders/{AccessToken}/Cancel.wplx", MVC.Order.Cancel());

            routes.MapRoute("Order-Submit", "Orders/Submit.wplx", MVC.Order.Submit());

            routes.MapRoute("Order-CheckOut", "Orders/{AccessToken}/CheckOut.wplx", MVC.Order.CheckOut());

            routes.MapRoute("Order-PreparePaymentRequest", "Orders/{AccessToken}/Prepare-Payment-Request.wplx", MVC.Order.PreparePaymentRequest());

            routes.MapRoute("Order-Track", "Orders/Tracking.wplx", MVC.Order.Track());

            routes.MapRoute("Product-ListOrderDirection", "Products/{Order}-{Direction}.wplx", MVC.Product.List(null, null, null, null, null), null, new {
                Order = new EnumRouteConstraint<SortOrder>(),
                Direction = new EnumRouteConstraint<SortDirection>()
            });

            routes.MapRoute("Product-List", "Products.wplx", MVC.Product.List(null, null, null, null, null));

            routes.MapRoute("Product-ListByCategoryOrderDirection", "Products/{CategorySlug}/{Order}-{Direction}.wplx", MVC.Product.ListByCategory(null, null, null, null, null, null), null, new {
                CategorySlug = new SlugRouteConstraint(),
                Order = new EnumRouteConstraint<SortOrder>(),
                Direction = new EnumRouteConstraint<SortDirection>()
            });

            routes.MapRoute("Product-ListByCategory", "Products/{CategorySlug}.wplx", MVC.Product.ListByCategory(null, null, null, null, null, null), null, new {
                CategorySlug = new SlugRouteConstraint()
            });

            routes.MapRoute("Product-Details", "Products/{CategorySlug}/{ProductSlug}.wplx", MVC.Product.Details(), null, new {
                CategorySlug = new SlugRouteConstraint(),
                ProductSlug = new SlugRouteConstraint()
            });

            routes.MapRoute("Home-Sitemap", "Sitemap.xml", MVC.Home.Sitemap());

            routes.MapRoute("Home-Root", "", MVC.Home.Root());

            routes.MapRoute("HomeError", "{*catchAll}", MVC.Home.Error(new ErrorHandlingModel {
                HttpCode = HttpStatusCode.NotFound
            }));
        }
    }
}
