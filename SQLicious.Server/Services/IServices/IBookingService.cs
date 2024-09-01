using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs;

namespace SQLicious.Server.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task ReserveATableAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task CustomerTableExistsAsync(int tableId, int customerId);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);
    }
}
