using Microsoft.AspNetCore.Identity;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Booking;
using SQLicious.Server.Model.DTOs.Customer;
using SQLicious.Server.Model.DTOs.MenuItem;

namespace SQLicious.Server.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task <IdentityResult>ReserveATableAsync(BookingCreationDTO booking, CustomerCreationDTO customerDetails, MenuItemDTO menuItemDto);
        Task<BookingDTO> GetBookingByIdAsync(int bookingId);
        Task CustomerTableExistsAsync(int tableId, int customerId);
        Task UpdateBookingAsync(BookingDTO booking);
        Task DeleteBookingAsync(int bookingId);
    }
}
