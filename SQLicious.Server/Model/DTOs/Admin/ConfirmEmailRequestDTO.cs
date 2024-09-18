namespace SQLicious.Server.Model.DTOs.Admin
{
    public class ConfirmEmailRequestDTO
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
