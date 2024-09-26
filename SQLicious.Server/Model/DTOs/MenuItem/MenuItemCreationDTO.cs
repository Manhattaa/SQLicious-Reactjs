using SQLicious.Server.Model;

namespace SQLicious.Server.Model.DTOs.MenuItem
{
    public class MenuItemCreationDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public string Description { get; set; }

        public MenuType MenuType { get; set; }
    }
}
