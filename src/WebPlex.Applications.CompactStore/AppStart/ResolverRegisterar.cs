using System.Web;
using WebPlex.Applications.CompactStore.AppStart;

[assembly: PreApplicationStartMethod(typeof (ResolverRegisterar), "RegisterResolver")]

namespace WebPlex.Applications.CompactStore.AppStart {
    using System.Reflection;
    using System.Web.Mvc;
    using Autofac;
    using Autofac.Integration.Mvc;
    using WebPlex.Applications.CompactStore.Data;
    using WebPlex.Applications.CompactStore.Data.Repositories;

    public static class ResolverRegisterar {
        public static void RegisterResolver() {
            var builder = new ContainerBuilder();
            RegisterTypes(builder);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private static void RegisterTypes(ContainerBuilder builder) {
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<StoreContext>().AsSelf().InstancePerRequest();
            builder.Register(cc => HttpContext.Current.Session).AsSelf().InstancePerRequest();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>().InstancePerDependency();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().InstancePerDependency();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerDependency();
            builder.RegisterType<CartItemRepository>().As<ICartItemRepository>().InstancePerDependency();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerDependency();
            builder.RegisterType<OrderLineRepository>().As<IOrderLineRepository>().InstancePerDependency();
            builder.RegisterType<OrderComplaintRepository>().As<IOrderComplaintRepository>().InstancePerDependency();
        }
    }
}
