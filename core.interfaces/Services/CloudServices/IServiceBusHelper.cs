using System.Threading.Tasks;

namespace Core.Interfaces.CloudServices
{
    public interface IServiceBusHelper
    {
        Task SendMessageAsync(string Message, string queueName);
        Task<object> ReceiveMessageAsync();
    }
}
