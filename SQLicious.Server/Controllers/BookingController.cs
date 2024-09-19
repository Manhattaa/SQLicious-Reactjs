using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLicious.Server.Data;
using SQLicious.Server.Model;
using SQLicious.Server.Model.DTOs.Booking;
using SQLicious.Server.Model.DTOs.Customer;
using SQLicious.Server.Services.IServices;

namespace SQLicious.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly RestaurantContext _context;

        public BookingController(IBookingService bookingService, RestaurantContext context)
        {
            _bookingService = bookingService;
            _context = context;
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<CustomerDTO>> GetBookingById(int bookingId)
        {
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            return Ok(booking);
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveBooking([FromBody] BookingCreationDTO bookingDto)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(b => b.CustomerId == bookingDto.CustomerId);
            if (customer == null)
            {
                return NotFound("Customer was not found.");
            }

            var table = await _context.Tables.FindAsync(bookingDto.TableId);
            if (table == null)
            {
                return NotFound("Table was not found.");
            }

            // Create the booking
            var booking = new Booking
            {
                AmountOfCustomers = bookingDto.AmountOfCustomers,
                BookedDateTime = bookingDto.BookedDateTime,
                CustomerId = bookingDto.CustomerId,
                TableId = bookingDto.TableId
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return Ok(booking);
        }



        [HttpPut("Update")]
        public async Task<ActionResult> UpdateBooking(BookingDTO booking)
        {
            await _bookingService.UpdateBookingAsync(booking);
            return Ok("Booking updated successfully.");
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteBooking(int bookingId)
        {
            await _bookingService.DeleteBookingAsync(bookingId);
            return Ok("Booking deleted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookings()
        {
            var bookingList = await _bookingService.GetAllBookingsAsync();
            return Ok(bookingList);
        }
    }
}