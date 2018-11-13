using Core.Interfaces.Models;

namespace WebAPI.Interfaces.Services
{
    public interface ICustomerService
    {
        ICustomer GetCustomer(string id);
        ICustomer PostCustomer(ICustomer customer);
        ICustomer PutCustomer(ICustomer customer);
        bool DeleteCustomer(string id);
    }
}
