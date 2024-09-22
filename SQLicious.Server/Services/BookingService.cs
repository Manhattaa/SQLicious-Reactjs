using Microsoft.AspNetCore.Identity;
using SQLicious.Server.Data.Repository.IRepositories;
using SQLicious.Server.Helpers;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Booking;
using SQLicious.Server.Model.DTOs.Customer;
using SQLicious.Server.Model.DTOs.MenuItem;
using SQLicious.Server.Options.Email;
using SQLicious.Server.Options.Email.IEmail;
using SQLicious.Server.Services.IServices;
using System.Text.Encodings.Web;

namespace SQLicious.Server.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IEmailSender _emailSender;
        private readonly string _baseUrl = "https://localhost:5173";

        public BookingService(IBookingRepository bookingRepository, ICustomerRepository customerRepository, ITableRepository tableRepository, IEmailSender emailSender)
        {
            _bookingRepository = bookingRepository;
            _customerRepository = customerRepository;
            _tableRepository = tableRepository;
            _emailSender = emailSender;
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

        public async Task<IdentityResult> ReserveATableAsync(BookingCreationDTO booking, CustomerCreationDTO customerDetails, MenuItemDTO menuItemDto)
        {
            try
            {
                Console.WriteLine("ReserveATableAsync method is called.");

                // Check if customer and table exist
                await CustomerTableExistsAsync(booking.CustomerId, booking.TableId);
                Console.WriteLine("Customer and table validation passed.");

                DateTime dateTime = TimeHelper.DateTimeHelper(booking.BookedDateTime);
                Console.WriteLine("Booking DateTime: " + dateTime);

                // Step 1: Create the new booking
                var newBooking = new Booking
                {
                    AmountOfCustomers = booking.AmountOfCustomers,
                    CustomerId = booking.CustomerId,
                    TableId = booking.TableId,
                    BookedDateTime = dateTime
                };

                await _bookingRepository.ReserveATableAsync(newBooking);
                Console.WriteLine("Booking created successfully.");

                // Step 2: Before preparing the email
                Console.WriteLine("Preparing email...");

                string bookingConfirmationUrl = $"{_baseUrl}/confirm-booking?bookingId={newBooking.BookingId}";

                string emailSubject = "SQLicious - Din Bokning är Bekräftad!";
                string emailBody =
                    $"<h2>Hej {customerDetails.FirstName} {customerDetails.LastName}!</h2>" +
                    $"<p>Tack för din bokning på SQLicious! Här är dina bokningsdetaljer:<br>" +
                    $"<strong>Måltid:</strong> {menuItemDto.MenuType}<br>" +
                    $"<strong>Datum:</strong> {booking.BookedDateTime.ToShortDateString()}<br>" +
                    $"<strong>Tid:</strong> {booking.BookedDateTime.ToShortTimeString()}<br>" +
                    $"<strong>Bord:</strong> {booking.TableId}<br>" +
                    $"<strong>Antal Gäster:</strong> {booking.AmountOfCustomers}<br><br>" +
                    $"Du kan se eller ändra din bokning genom att klicka på följande länk:<br>" +
                    $"<a href='{HtmlEncoder.Default.Encode(bookingConfirmationUrl)}'>Bekräfta eller ändra din bokning här</a>.<br><br>" +
                    $"Vi ser fram emot ditt besök!<br>" +
                    $"SQLicious</p>";

                // Check if these values are null
                Console.WriteLine($"Booking Confirmation URL: {bookingConfirmationUrl}");
                Console.WriteLine($"Email Subject: {emailSubject}");
                Console.WriteLine($"Email Body: {emailBody}");
                Console.WriteLine($"Sending email to: {customerDetails.Email}");

                // Step 3: Send confirmation email to the customer
                var sendEmailResult = await _emailSender.SendEmailAsync(customerDetails.Email, emailSubject, emailBody);
                if (!sendEmailResult.Success)
                {
                    return IdentityResult.Failed(new IdentityError
                    {
                        Description = $"Failed to send email: {string.Join(", ", sendEmailResult.ErrorMessage)}"
                    });
                }

                // Step 4: Return success result
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw new Exception($"An error occurred while trying to create booking: {ex.Message}");
            }
        }


        private async Task<int> GetNextCustomerIdAsync()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomersAsync();
                if (customers.Count() == 0) return 1;

                return customers.Max(c => c.CustomerId) + 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to get the next CustomerId: {ex.Message}");
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
