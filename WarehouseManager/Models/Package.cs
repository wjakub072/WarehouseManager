using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManager.Models
{
    [Table("Packages", Schema ="WM")]
    internal class Package
    {
        [Key]
        public int Package_Id { get; set; }
        public string Name { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public string Unit { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
