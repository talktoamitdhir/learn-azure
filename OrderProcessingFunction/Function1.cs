using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;

namespace OrderProcessingFunction
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("OrderQueue", AccessRights.Manage, Connection = "")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
