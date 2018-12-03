using System.Collections.Generic;
using System.Threading.Tasks;
using core.Interfaces.Repositories;
using core.Interfaces.Services.CloudServices;
using Core.Interfaces.Models;
using Core.Models;

namespace Core.Repository
{
    public class CustomerRepository : DocumentDbRespository, ICustomerRepository
    {
        public CustomerRepository(IDocumentDBHelper documentDBHelper) : base(documentDBHelper)
        {
        }

        public async Task<ICustomer> GetCustomerAsync(string id)
        {
            return await GetAsync<Customer>(id, "Customers");
        }

        public async Task<IList<ICustomer>> GetCustomersAsync(IList<string> ids)
        {
            return await GetAsync<ICustomer>(ids);
        }

        public async Task<IEnumerable<ICustomer>> GetAllCustomersAsync()
        {
            return await GetAllAsync<Customer>("Customers");
        }

        public async Task<bool> InsertCustomerAsync(ICustomer customer)
        {
            return await InsertAsync<ICustomer>(customer, "Customers");
        }

        public async Task<bool> InsertCustomersAsync(IEnumerable<ICustomer> customers)
        {
            return await InsertAsync<ICustomer>(customers);
        }

        public async Task<bool> UpsertCustomerAsync(ICustomer customer)
        {
            return await UpsertAsync<ICustomer>(customer);
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            return await DeleteAsync<ICustomer>(id);
        }
    }
}
