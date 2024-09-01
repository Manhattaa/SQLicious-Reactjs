using System.Text.Json.Serialization;

namespace SQLicious.Server.Model.DTOs
{
    public class BookingCreationDTO
    {
        public int AmountOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
    }
}
