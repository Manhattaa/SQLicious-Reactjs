using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<CustomerDTO>> GetBookingById(int bookingId)
        {
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            return Ok(booking);
        }

        [HttpPost("reserve")]
        public async Task<IActionResult> ReserveTable([FromBody] BookingCreationDTO booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _bookingService.ReserveATableAsync(booking);
                return Ok(new { Message = "Booking successfully created!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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