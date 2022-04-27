using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManager.Models
{
    [Table("Addresses", Schema = "WM")]
    internal class Address
    {
        [Key]
        public int Address_Id { get; set; }
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }
        public byte IsDefault { get; set; }

        [NotMapped]
        public string StreetAddress { get { return Street + " " + Building; } }

        public override string ToString()
        {
            return City + " " + Street + " " + Building;
        }
    }
}
