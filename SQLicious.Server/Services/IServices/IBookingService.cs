using SQLicious.Server.Model;

namespace SQLicious.Server.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task ReserveATableAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task<Booking> UserTableExistsAsync(int tableId, int customerId);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);
    }
}
