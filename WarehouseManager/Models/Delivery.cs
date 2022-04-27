using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManager.Models
{
    [Table("Deliveries", Schema ="WM")]
    internal class Delivery
    {
        [Key]
        public int Delivery_Id { get; set; }
        public int DocumentId { get; set; }
        public DateTime AssumedDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal ValidQuantity { get; set; }
    }
}
