using System.Text.Json.Serialization;

namespace SQLicious.Server.Model.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int ÁmountOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
    }
}
