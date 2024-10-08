﻿using Microsoft.AspNetCore.Http;
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



        [HttpPut("update")]
        public async Task<ActionResult> UpdateBooking(BookingDTO booking)
        {
            await _bookingService.UpdateBookingAsync(booking);
            return Ok("Booking updated successfully.");
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteBooking(int bookingId)
        {
            await _bookingService.DeleteBookingAsync(bookingId);
            return Ok("Booking deleted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookings()
        {
            var bookings = await _context.Bookings
                .Include(b => b.Customer)  // Eagerly load Customer data
                .ToListAsync();

            var bookingList = bookings.Select(b => new BookingDTO
            {
                BookingId = b.BookingId,
                AmountOfCustomers = b.AmountOfCustomers,
                TableId = b.TableId,
                BookedDateTime = b.BookedDateTime,
                Customer = b.Customer != null ? new CustomerDTO
                {
                    CustomerId = b.Customer.CustomerId,
                    FirstName = b.Customer.FirstName,
                    LastName = b.Customer.LastName,
                    Email = b.Customer.Email
                } : null  // handles null customer cases
            }).ToList();

            return Ok(bookingList);
        }

        [HttpGet("BookingStatistics")]
        public async Task<IActionResult> GetBookingStatistics()
        {
            var totalBookings = await _context.Bookings.CountAsync();
            return Ok(new { totalBookings });
        }
    }
}