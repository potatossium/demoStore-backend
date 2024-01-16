using AutoMapper;
using DemoStoreWeek7.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStoreWeek7.Services
{
    public class CustomerService: ICustomerService
    {
        private readonly DemoStoreDBContext _context;
        public CustomerService(DemoStoreDBContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            // ToListAsync() method is from EntityFrameworkCore
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }
        public async Task<Customer> GetCustomer(int? id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }
        public async Task<int> CreateCustomer(CreateCustomer model)
        {
            var customer = new Customer
            {
                Name = model.Name,
                Address = model.Address
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<Customer> UpdateCustomer(UpdateCustomer model)
        {
            var customer = new Customer
            {
                Name = model.Name,
                Address = model.Address
            };
            var existingCustomer = await _context.Customers.FindAsync(model.Id);
            if (existingCustomer == null)
            {
                return null;
            }
            existingCustomer.Name = model.Name;
            existingCustomer.Address = model.Address;

            _context.Customers.Update(existingCustomer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = new Customer { Id = id };
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

    }
}
