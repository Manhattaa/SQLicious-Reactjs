using System.ComponentModel.DataAnnotations;

namespace SQLicious.Server.Model
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable {  get; set; }
    }
}
