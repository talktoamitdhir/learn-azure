using Core.Interfaces.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<ICustomer> GetCustomerAsync(string id);
        Task<IList<ICustomer>> GetCustomersAsync(IList<string> ids);
        Task<IEnumerable<ICustomer>> GetAllCustomersAsync();
        Task<bool> InsertCustomerAsync(ICustomer customer);
        Task<bool> InsertCustomersAsync(IEnumerable<ICustomer> customers);
        Task<bool> UpsertCustomerAsync(ICustomer customer);
        Task<bool> DeleteCustomerAsync(string id);
    }
}
