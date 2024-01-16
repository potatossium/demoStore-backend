using DemoStoreWeek7.Models;

namespace DemoStoreWeek7.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomer(int? id);
        Task<int> CreateCustomer(CreateCustomer model);
        Task<Customer> UpdateCustomer(UpdateCustomer model);
        Task DeleteCustomer(int Id);
    }
}
