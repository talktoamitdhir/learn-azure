using Core.Interfaces.Models;
using System.Threading.Tasks;

namespace WebAPI.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IOrder> GetOrderAsync(string id);
        IOrder PostOrder(IOrder order);
        IOrder PutOrder(IOrder order);
        bool DeleteOrder(string id);
    }
}
