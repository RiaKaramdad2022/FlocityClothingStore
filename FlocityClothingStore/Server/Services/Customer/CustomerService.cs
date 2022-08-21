using FlocityClothingStore.Server.Data;
using FlocityClothingStore.Shared.Models.Customer;
using Microsoft.EntityFrameworkCore;
using FlocityClothingStore.Server.Models;
using FlocityClothingStore.Shared.Models.Transaction;

namespace FlocityClothingStore.Server.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        //Our Customer Controller will use this service rather than talking to the database directly. It will only serve HTTP endpoints.
        // This  class will only deliver data using the Shared models. This is an example of Separation of Responsibilities.

        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
       public async Task<bool> CreateCustomerAsync (CustomerCreate model)
        {
            if (model == null) return false;
            var customerEntity = new Models.Customer
            {
                FullName = model.FullName,
                Email = model.Email
            };
            _context.Customers.Add(customerEntity);
            return await _context.SaveChangesAsync() == 1; 
        }

        public async Task<IEnumerable<CustomerListItem>> GetAllCustomersAsync()
        {
            var customers = _context.Customers.Select(customer => new CustomerListItem
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email
            });
            return await customers.ToListAsync();
        }
        public async Task<CustomerDetail> GetCustomerByIdAsync(int CustomerId)
        {
            var customer = await _context.Customers.FindAsync(CustomerId);

            if (customer is null) return null;

            return new CustomerDetail
            {
                Id = customer.Id,
                FullName = customer.FullName,
                Email = customer.Email,
            };
        }

        //The Update method will find the existing Customer and return false if it doesn't exist, then alter the details, and save the changes asynchronously.
        public async Task<bool> UpdateCustomerAsync(CustomerEdit model)
        {
            var customer = await _context.Customers.FindAsync(model.Id);

            if (customer is null) return false;

            customer.FullName = model.FullName;
            customer.Email = model.Email;

            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }
        
        // Delete Method will take in a customerId and return a boolean that indicates whether or not deletion was successful.

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            // First, we need to make sure that the customer exiists (find the customer) then return false if they he/she doesn't.
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer is null) return false;
            // once we find the customer, we can remove them from the database and then save changes asynchoronously 
            _context.Customers.Remove(customer);
            if (await _context.SaveChangesAsync() == 1)
                return true;
            return false;
        }

    }
}
