using Core.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IOrderRespository
    {
        Task<IOrder> GetOrderAsync(string id);
        Task<IList<IOrder>> GetOrdersAsync(IList<string> ids);
        Task<IList<IOrder>> GetAllOrdersAsync();
        Task<bool> InsertOrderAsync(IOrder order);
        Task<bool> InsertOrdersAsync(IEnumerable<IOrder> orders);
        Task<bool> UpsertOrderAsync(IOrder order);
        Task<bool> DeleteOrderAsync(string id);
    }
}
