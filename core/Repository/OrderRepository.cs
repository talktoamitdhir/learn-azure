using Core.Interfaces.Repositories;
using Core.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using core.Interfaces.Services.CloudServices;
using Core.Models;

namespace Core.Repository
{
    public class OrderRepository : DocumentDbRespository, IOrderRespository
    {

        public OrderRepository(IDocumentDBHelper documentDBHelper) : base(documentDBHelper)
        {
        }

        public async Task<IOrder> GetOrderAsync(string id)
        {
            return await GetAsync<Order>(id, "Orders"); 
        }

        public async Task<IList<IOrder>> GetOrdersAsync(IList<string> ids)
        {
            return await GetAsync<IOrder>(ids);
        }

        public async Task<IList<IOrder>> GetAllOrdersAsync()
        {
            return await GetAllAsync<IOrder>();
        }

        public async Task<bool> InsertOrderAsync(IOrder order)
        {
            return await InsertAsync<IOrder>(order);
        }

        public async Task<bool> InsertOrdersAsync(IEnumerable<IOrder> orders)
        {
            return await InsertAsync<IOrder>(orders);
        }

        public async Task<bool> UpsertOrderAsync(IOrder order)
        {
            return await UpsertAsync<IOrder>(order);
        }

        public async Task<bool> DeleteOrderAsync(string id)
        {
            return await DeleteAsync<IOrder>(id);
        }
    }
}
