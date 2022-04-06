using System;

namespace WarehouseManager.Models
{
    internal class Delivery
    {
        public int Delivery_Id { get; set; }
        public int DocumentId { get; set; }
        public DateTime AssumedDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal ValidQuantity { get; set; }
    }
}
