using Core.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IOrder> GetOrderAsync(string id);
        Task<IEnumerable<IOrder>> GetOrdersAsync();
        IOrder PostOrder(IOrder order);
        IOrder PutOrder(IOrder order);
        bool DeleteOrder(string id);
    }
}
