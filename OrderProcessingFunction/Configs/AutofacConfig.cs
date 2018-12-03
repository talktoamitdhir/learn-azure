using Autofac;
using AzureFunctions.Autofac.Configuration;
using core.Interfaces.Services.CloudServices;
using Core.Interfaces.CloudServices;
using Core.Interfaces.Repositories;
using Core.Repository;
using Core.Services;
using Microsoft.Azure.Documents;

namespace OrderProcessingFunction.Configs
{
    public class AutofacConfig
    {
        private static bool _alreadyRegistered;
        private static readonly object locker = new object();


        public AutofacConfig(string functionName)
        {
            if (_alreadyRegistered) return;
            lock (locker)
            {
                if (_alreadyRegistered) return;
                _alreadyRegistered = true;
            }



            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterInstance(new KeyVaultHelper())
                        .As<IKeyVaultHelper>()
                        .SingleInstance();

                builder.RegisterType<DocumentDBHelper>()
                        .As<IDocumentDBHelper>()
                        .SingleInstance();

                builder.RegisterType<OrderRepository>()
                        .As<IOrderRepository>()
                        .InstancePerLifetimeScope();

                //builder.RegisterType<DocumentClient>()
                //        .As<IDocumentClient>()
                //        .WithParameter(new NamedParameter("serviceEndpoint", ""))
                //        .WithParameter(new NamedParameter("authKey", ""))
                //        .SingleInstance();

            },
            functionName);
        }
    }
}
