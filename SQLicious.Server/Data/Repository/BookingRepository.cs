using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Model;

namespace SQLicious.Server.Data.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly RestaurantContext _context;

        public BookingRepository(RestaurantContext context)
        {
            _context = context;
        }
        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);

            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var listOfBookings = await _context.Bookings.ToListAsync();
            return listOfBookings;
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            return booking;
        }

        public async Task ReserveATableAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }
    }
}
