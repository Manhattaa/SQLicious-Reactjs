using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Booking;

namespace SQLicious.Server.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task ReserveATableAsync(BookingCreationDTO booking);
        Task<BookingDTO> GetBookingByIdAsync(int bookingId);
        Task CustomerTableExistsAsync(int tableId, int customerId);
        Task UpdateBookingAsync(BookingDTO booking);
        Task DeleteBookingAsync(int bookingId);
    }
}
