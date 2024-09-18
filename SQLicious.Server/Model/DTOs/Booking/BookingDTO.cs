using System.Text.Json.Serialization;

namespace SQLicious.Server.Model.DTOs.Booking
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int AmountOfCustomers { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
        public DateTime BookedDateTime { get; set; }
    }
}
