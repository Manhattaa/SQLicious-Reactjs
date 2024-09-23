using SQLicious.Server.Model.DTOs.MenuItem;

namespace SQLicious.Server.Services.IServices
{
    public interface IPDFService
    {
        byte[] GenerateMenuPdf(IEnumerable<PDFMenuItemDTO> menuItems, string menuType);
    }
}
