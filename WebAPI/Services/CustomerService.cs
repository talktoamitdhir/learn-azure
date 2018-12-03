using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces.Models;
using WebAPI.Interfaces.Services;
using core.Interfaces.Repositories;

namespace WebAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool DeleteCustomer(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICustomer> GetCustomerAsync(string id)
        {
            return await _customerRepository.GetCustomerAsync(id);
        }

        public async Task<IEnumerable<ICustomer>> GetCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public ICustomer PutCustomer(ICustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}