﻿using Autofac;
using AzureFunctions.Autofac.Configuration;
using Core.Interfaces.CloudServices;
using Core.Interfaces.Repositories;
using Core.Repository;
using Core.Services;
using Microsoft.Azure.Documents;

namespace OrderProcessingFunction.Configs
{
    class AutofacConfig
    {
        private static bool _alreadyRegistered;
        private static readonly object locker = new object();


        public AutofacConfig()
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
                        .As<IDocumentClient>()
                        .SingleInstance();

                builder.RegisterType<OrderRepository>()
                        .As<IOrderRespository>()
                        .InstancePerLifetimeScope();

                //builder.RegisterType<DocumentClient>()
                //        .As<IDocumentClient>()
                //        .WithParameter(new NamedParameter("serviceEndpoint", ""))
                //        .WithParameter(new NamedParameter("authKey", ""))
                //        .SingleInstance();

            },
            "Orders");
        }
    }
}
