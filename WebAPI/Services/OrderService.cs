using Core.Interfaces.Models;
using Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Interfaces.Services;

namespace WebAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRespository _orderRespository;
        public OrderService(IOrderRespository orderRespository)
        {
            _orderRespository = orderRespository;
        }
        public bool DeleteOrder(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IOrder> GetOrderAsync(string id)
        {
            return await _orderRespository.GetOrderAsync(id);
        }

        public async Task<IEnumerable<IOrder>> GetOrdersAsync()
        {
            return await _orderRespository.GetAllOrdersAsync();
        }

        //public async Task<bool> PostOrder(IOrder order)
        //{
        //    return await _orderRespository.InsertOrderAsync(order);
        //}

        public IOrder PutOrder(IOrder order)
        {
            throw new System.NotImplementedException();
        }
    }
}