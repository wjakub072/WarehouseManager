using System.ComponentModel.DataAnnotations;

namespace WarehouseManager.Models
{
    internal class Warehouse
    {
        [Key]
        public int Warehouse_Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string Building { get; set; }
    }
}
