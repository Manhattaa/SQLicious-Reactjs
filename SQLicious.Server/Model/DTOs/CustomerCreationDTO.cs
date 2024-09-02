namespace SQLicious.Server.Model.DTOs
{
    public class CustomerCreationDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
