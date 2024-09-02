using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Helpers;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITableRepository _tableRepository;

        public BookingService(IBookingRepository bookingRepository, ICustomerRepository customerRepository, ITableRepository tableRepository)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
            _tableRepository = tableRepository;
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            try
            {
                await _bookingRepository.DeleteBookingAsync(bookingId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while attempting to delete Booking: {ex.Message}");
            }

        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            try
            {
                var listOfBookings = await _bookingRepository.GetAllBookingsAsync();

                return listOfBookings.Select(b => new BookingDTO
                {
                    BookingId = b.BookingId,
                    AmountOfCustomers = b.AmountOfCustomers,
                    BookedDateTime = b.BookedDateTime,
                    CustomerId = b.CustomerId,
                    TableId = b.TableId
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<BookingDTO> GetBookingByIdAsync(int bookingId)
        {
            try
            {
                var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);

                if (booking == null) { return null; }

                return new BookingDTO
                {
                    BookingId = bookingId,
                    AmountOfCustomers = booking.AmountOfCustomers,
                    BookedDateTime = booking.BookedDateTime,
                    CustomerId = booking.CustomerId,
                    TableId = booking.TableId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task ReserveATableAsync(BookingCreationDTO booking)
        {
            await CustomerTableExistsAsync(booking.CustomerId, booking.TableId);

            DateTime dateTime = TimeHelper.DateTimeHelper(booking.BookedDateTime);

            try
            {
                var newBooking = new Booking
                {
                    AmountOfCustomers = booking.AmountOfCustomers,
                    CustomerId = booking.CustomerId,
                    TableId = booking.TableId,
                    BookedDateTime = dateTime
                };

                await _bookingRepository.ReserveATableAsync(newBooking);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to create booking. {ex.Message}");
            }

        }
    

        public async Task UpdateBookingAsync(BookingDTO booking)
        {
            await CustomerTableExistsAsync(booking.CustomerId, booking.TableId);

            DateTime dateTime = TimeHelper.DateTimeHelper(booking.BookedDateTime);

            try
            {
                var newBooking = new Booking
                {
                    CustomerId = booking.CustomerId,
                    TableId = booking.TableId,
                    AmountOfCustomers = booking.AmountOfCustomers,
                    BookedDateTime = dateTime,
                };

                await _bookingRepository.ReserveATableAsync(newBooking);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to create this Booking: {ex.Message}");
            }

        }
        public async Task UpdateBookignAsync(BookingDTO booking)
        {
            await CustomerTableExistsAsync(booking.CustomerId, booking.TableId);

            DateTime dateTime = TimeHelper.DateTimeHelper(booking.BookedDateTime);
            try
            {
                var updatedBooking = new Booking
                {
                    BookingId = booking.BookingId,
                    AmountOfCustomers = booking.AmountOfCustomers,
                    CustomerId = booking.CustomerId,
                    TableId = booking.TableId,
                    BookedDateTime = dateTime,
                };

                await _bookingRepository.UpdateBookingAsync(updatedBooking);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to update this Booking: {ex.Message}");
            }
        }

        public async Task CustomerTableExistsAsync(int tableId, int customerId)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
                if (customer == null) throw new Exception("Customer was not found.");

                var table = await _tableRepository.GetTableByIdAsync(tableId);
                if (table == null) throw new Exception("Table was not found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
