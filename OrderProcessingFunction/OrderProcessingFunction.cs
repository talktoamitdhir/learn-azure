using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;
using Core.Config;
using AzureFunctions.Autofac;
using OrderProcessingFunction.Configs;
using Core.Interfaces.Repositories;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Core.Interfaces.Models;

namespace OrderProcessingFunction
{
    // TODO : Uncomment the below part if dependency injection it doesn't work.
    //[DependencyInjectionConfig(typeof(AutofacConfig))]
    public static class OrderProcessingFunction
    {
        [FunctionName("Orders")]
        public static async Task Run(
            [ServiceBusTrigger(PlatformConfigurationConstants.QUEUE_NAME, AccessRights.Manage, Connection = "")]string myQueueItem, 
            TraceWriter log,
            [Inject]IOrderRespository OrderRespository)
        {
            //TODO : Get the connection from key vault.
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            if (myQueueItem != null)
            {
                await PostOrder(myQueueItem, OrderRespository);
            }
        }

        private static async Task<bool> PostOrder(string myQueueItem, IOrderRespository OrderRespository)
        {
            var order = JsonConvert.DeserializeObject<IOrder>(myQueueItem);
            return await OrderRespository.InsertOrderAsync(order);
        }
    }
}
