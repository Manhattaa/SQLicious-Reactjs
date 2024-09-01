using System.ComponentModel.DataAnnotations;

namespace SQLicious.Server.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
