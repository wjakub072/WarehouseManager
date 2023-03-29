using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManager.Models
{
    [Table("Elements", Schema ="WM")]
    internal class Element
    {
        [Key]
        public int Element_Id { get; set; }
        public int DeliveryId { get; set; }
        public int PackageId { get; set; }
        public int AddressId { get; set; }
        public byte Insured { get; set; }
        public decimal Value { get; set; }
        public string SerialCode { get; set; }
        public byte Damaged { get; set; }
        public decimal Amount { get; set; }
    }
}
