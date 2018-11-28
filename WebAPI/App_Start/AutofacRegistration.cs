using Autofac;
using Autofac.Integration.WebApi;
using Core.Repository;
using Core.Services;
using System.Reflection;
using System.Web.Http;
using WebAPI.Services;

namespace WebAPI.App_Start
{
    public static class AutofacRegistration
    {
        public static IContainer _container;
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterDependencies(builder);
            _container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
        }

        public static void RegisterDependencies(ContainerBuilder builder)
        {
            builder.RegisterType<OrderService>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<OrderRepository>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<DocumentDBHelper>()
                 .AsImplementedInterfaces()
                 .SingleInstance();

            builder.RegisterType<KeyVaultHelper>()
                 .AsImplementedInterfaces()
                 .SingleInstance();

        }
    }
}