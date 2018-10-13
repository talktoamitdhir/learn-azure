using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
