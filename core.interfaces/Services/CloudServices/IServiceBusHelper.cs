namespace Interfaces
{
    interface IServiceBusHelper
    {
        void SendMessageToQueue();
        void ReceiveMessageFromQueue();
        void SendMessageToTopic();
        void ReceiveMessageFromTopic();
    }
}
