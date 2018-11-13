using Autofac;
using AzureFunctions.Autofac.Configuration;
using Core.Interfaces.CloudServices;
using Core.Services;

namespace OrderProcessingFunction.Configs
{
    class AutofacConfig
    {
        private static bool _alreadyRegistered;
        private static readonly object locker = new object();


        public AutofacConfig()
        {
            if (_alreadyRegistered) return;
            lock(locker)
            {
                if (_alreadyRegistered) return;
                _alreadyRegistered = true;
            }

            DependencyInjection.Initialize(builder =>
            {
                builder.RegisterInstance(new KeyVaultHelper())
                        .As<IKeyVaultHelper>()
                        .SingleInstance();
                        
            },
            "Function1");
        }
    }
}
