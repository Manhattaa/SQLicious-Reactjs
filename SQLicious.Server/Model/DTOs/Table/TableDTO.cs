namespace SQLicious.Server.Model.DTOs.Table
{
    public class TableDTO
    {
        public int TableId { get; set; }
        public int SeatingCapacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
