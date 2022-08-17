using FlocityClothingStore.Shared.Models.Customer;

namespace FlocityClothingStore.Server.Services.Customer
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(CustomerCreate model);
        Task<IEnumerable<CustomerListItem>> GetAllCustomersAsync();
        Task<CustomerDetail> GetCustomerByIdAsync(int CustomerId);
        Task<bool> UpdateCustomerAsync(CustomerEdit model);
        Task<bool> DeleteCustomerAsync(int customerId);

    }
}
