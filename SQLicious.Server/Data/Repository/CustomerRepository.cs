using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model;

namespace SQLicious.Server.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantContext _context;

        public CustomerRepository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task CreateCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var listOfCustomers = await _context.Customers.ToListAsync();
            return listOfCustomers;
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            return customer;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
