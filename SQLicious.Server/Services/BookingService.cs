using SQLicious.Server.Model;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Services
{
    public class BookingService : IBookingService
    {
        public Task DeleteBookingAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task ReserveATableAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
