using System.Text.Json.Serialization;

namespace SQLicious.Server.Model.DTOs.Booking
{
    public class BookingCreationDTO
    {
        public int AmountOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        public int CustomerId { get; set; }
        public int TableId { get; set; }
    }
}
