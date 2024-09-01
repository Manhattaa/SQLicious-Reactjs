using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs;

namespace SQLicious.Server.Services.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int customerId);
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(CustomerDTO customer);
        Task DeleteCustomerAsync(int customerId);
    }
}
