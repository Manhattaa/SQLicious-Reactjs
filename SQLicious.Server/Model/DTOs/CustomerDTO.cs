using System.Text.Json.Serialization;

namespace SQLicious.Server.Model.DTOs
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
