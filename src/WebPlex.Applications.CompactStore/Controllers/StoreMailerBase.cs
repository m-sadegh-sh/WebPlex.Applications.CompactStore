using MailerBase = Mvc.Mailer.MailerBase;

namespace WebPlex.Applications.CompactStore.Controllers {
    using System.Web.Mvc;
    using System.Web.Routing;
    using T4MVC;

    public abstract class StoreMailerBase : MailerBase {
        protected StoreMailerBase() {
            MasterName = Views.Shared._MailerLayout_cshtml;
            Url = new UrlHelper(new RequestContext(CurrentHttpContext, new RouteData()));
        }

        protected UrlHelper Url { get; set; }
    }
}
