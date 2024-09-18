using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Customer;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task CreateCustomerAsync(CustomerCreationDTO customer)
        {
            try
            {
                var newCustomer = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                };

                await _customerRepository.CreateCustomerAsync(newCustomer);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to create Customer: {ex.Message}");
            }
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            try
            {
                await _customerRepository.DeleteCustomerAsync(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to delete Customer: {ex.Message}");
            }
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {
            try
            {
                var listOfCustomers = await _customerRepository.GetAllCustomersAsync();

                return listOfCustomers.Select(c => new CustomerDTO
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int customerId)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(customerId);

                if (customer == null) { return null; }

                return new CustomerDTO
                {
                    CustomerId = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.FirstName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task UpdateCustomerAsync(CustomerDTO customer)
        {
            try
            {
                if (customer != null)
                {
                    var updatedCustomer = new Customer
                    {
                        CustomerId = customer.CustomerId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Email = customer.Email,
                        PhoneNumber = customer.PhoneNumber
                    };

                    await _customerRepository.UpdateCustomerAsync(updatedCustomer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to update Customer: {ex.Message}");
            }
        }
    }
}
