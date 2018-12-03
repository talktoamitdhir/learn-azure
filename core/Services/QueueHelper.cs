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
        private IQueueClient _queueClient;
        private readonly IKeyVaultHelper _keyVaultHelper;

        public QueueHelper(IKeyVaultHelper keyVaultHelper)
        {
            _keyVaultHelper = keyVaultHelper;
        }

        public async Task<IQueueClient> GetQueueClientAsync(string queueName)
        {
            try
            {
                string SERVICE_BUS_QUEUE_CONNECTIONSTRING = await _keyVaultHelper.GetSecretAsync(PlatformConfigurationConstants.SERVICEBUS_CONNECTION_STRING);
                _queueClient = new QueueClient(SERVICE_BUS_QUEUE_CONNECTIONSTRING, queueName);
                return _queueClient;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task SendMessageAsync(string message, string queueName)
        {
            await GetQueueClientAsync(queueName);

            var queueMessage = new Message(Encoding.UTF8.GetBytes(message));
            await _queueClient.SendAsync(queueMessage);
        }

        Task<object> IServiceBusHelper.ReceiveMessageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
