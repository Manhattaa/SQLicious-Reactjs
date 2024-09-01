namespace SQLicious.Server.Model.DTOs
{
    public class CustomerCreationDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
