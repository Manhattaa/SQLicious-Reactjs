using System.ComponentModel.DataAnnotations;

namespace SQLicious.Server.Model
{

    public enum MenuType
    {
        Frukost,
        Brunch,
        Lunch,
        Middag,
        Julbord
    }
    public class MenuItems
    {
        [Key]
        public int MenuItemId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }

        public MenuType MenuType { get; set; }
    }
}
