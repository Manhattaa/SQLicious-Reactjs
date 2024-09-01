using SQLicious.Server.Model;

namespace SQLicious.Server.Data.Repository.IRepositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task ReserveATableAsync(Booking booking);
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);
    }
}
