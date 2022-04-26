using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManager.Models
{
    [Table("Sectors", Schema ="WM")]
    internal class Sector
    {
        [Key]
        public int Sector_Id { get; set; }
        public int WarehouseId { get; set; }
        public string Code { get; set; }
        public decimal Capacity { get; set; }
        public string Unit { get; set; }
        public decimal Used { get; set; }
        public string Mostly { get; set; }

        [NotMapped]
        public string Size => Capacity + " "+ Unit;
        [NotMapped]
        public string Percent => Used + " %";
    }
}
