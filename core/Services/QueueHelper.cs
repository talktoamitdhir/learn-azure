using Core.Interfaces.CloudServices;
using System;
using Core.Config;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class QueueHelper : IServiceBusHelper
    {
        private readonly IQueueClient _queueClient;
        private readonly IKeyVaultHelper _keyVaultHelper;

        public QueueHelper(IKeyVaultHelper keyVaultHelper)
        {
            _keyVaultHelper = keyVaultHelper;
            //TODO : Use KeyVault to retrieve connection string;
            
            _queueClient = new QueueClient(new ServiceBusConnectionStringBuilder(PlatformConfigurationConstants.SERVICEBUS_CONNECTION_STRING));
        }

        public async Task SendMessageAsync(string message)
        {
            var queueMessage = new Message(Encoding.UTF8.GetBytes(message));
            await _queueClient.SendAsync(queueMessage);
        }

        Task<object> IServiceBusHelper.ReceiveMessageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
