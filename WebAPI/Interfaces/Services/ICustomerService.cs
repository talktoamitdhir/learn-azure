using Core.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<ICustomer> GetCustomerAsync(string id);
        Task<IEnumerable<ICustomer>> GetCustomersAsync();
        //ICustomer PostCustomer(ICustomer customer);
        ICustomer PutCustomer(ICustomer customer);
        bool DeleteCustomer(string id);
    }
}
