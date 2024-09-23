using System.ComponentModel.DataAnnotations;

namespace SQLicious.Server.Model
{
    public class MenuPDF
    {
        [Key]
        public int MenuPDFId { get; set; }

        [Required]
        public MenuType MenuType { get; set; }

        public string PdfUrl { get; set; }
    }
}
