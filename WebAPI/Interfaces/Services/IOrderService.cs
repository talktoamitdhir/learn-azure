using Core.Interfaces.Models;

namespace WebAPI.Interfaces.Services
{
    public interface IOrderService
    {
        IOrder GetOrder(string id);
        IOrder PostOrder(IOrder order);
        IOrder PutOrder(IOrder order);
        bool DeleteOrder(string id);
    }
}
