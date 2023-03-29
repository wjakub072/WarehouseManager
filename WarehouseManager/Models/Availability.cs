using Microsoft.EntityFrameworkCore;

namespace WarehouseManager.Models
{
    [Keyless]
    internal class Availability // later map to procedure result
    {
        public string CustomerName { get; set; }
        public string SerialCode { get; set; }
        public string Package { get; set; }
        public decimal Amount { get; set; }
        public decimal Value { get; set; }
    }
}
