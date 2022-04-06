namespace WarehouseManager.Models
{
    internal class Package
    {
        public int Package_Id { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public string Unit { get; set; }
    }
}
