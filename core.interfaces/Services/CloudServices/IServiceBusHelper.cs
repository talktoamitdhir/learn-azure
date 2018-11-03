namespace Core.Interfaces.CloudServices
{
    interface IServiceBusHelper
    {
        void SendMessageToQueue();
        void ReceiveMessageFromQueue();
        void SendMessageToTopic();
        void ReceiveMessageFromTopic();
    }
}
