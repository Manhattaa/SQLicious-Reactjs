namespace SQLicious.Server.Services
{
    using DinkToPdf;
    using DinkToPdf.Contracts;
    using SQLicious.Server.Model.DTOs.MenuItem;
    using SQLicious.Server.Services.IServices;
    using System.Text;

    public class PDFService : IPDFService
    {
        private readonly IConverter _converter;

        public PDFService(IConverter converter)
        {
            _converter = converter;
        }

        public byte[] GenerateMenuPdf(IEnumerable<PDFMenuItemDTO> menuItems, string menuType)
        {
            var sb = new StringBuilder();

            sb.Append($"<h1 style='text-align: center;'>Veckans {menuType} Meny!</h1>");
            sb.Append($"<h3 style='text-align: center;'>Här på SQLicious tillagas all mat med kärlek</h3>");

            foreach (var item in menuItems)
            {
                sb.Append("<div style='margin-bottom: 20px; border-bottom: 1px solid #ccc; padding-bottom: 10px;'>");
                sb.Append("<div style='width: 100%; position: relative;'>");
                sb.Append($"<h2 style='margin: 0; font-size: 18px; float: left;'>{item.Name}</h2>");
                sb.Append($"<p style='margin: 0; font-size: 14px; font-weight: bold; float: right;'>{item.Price:C}</p>");
                sb.Append("</div>");
                sb.Append("<div style='clear: both;'></div>");
                sb.Append($"<p style='margin: 5px 0; font-size: 12px; color: gray;'>{item.Description}</p>");
                sb.Append("</div>");
            }

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
        },
                Objects = {
            new ObjectSettings() {
                PagesCount = true,
                HtmlContent = sb.ToString(),
                WebSettings = { DefaultEncoding = "utf-8" }
            }
        }
            };

            return _converter.Convert(doc);
        }
    }
}
