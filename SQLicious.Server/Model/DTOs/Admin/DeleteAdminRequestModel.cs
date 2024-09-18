using System.ComponentModel.DataAnnotations;

namespace SQLicious.Server.Model.DTOs.Admin
{
    public class DeleteAdminRequestModel
    {
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(256, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
