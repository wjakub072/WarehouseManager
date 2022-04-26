using Microsoft.EntityFrameworkCore;

namespace WarehouseManager.Models
{
    [Keyless]
    internal class Availability // later map to procedure result
    {
        public string CustomerName { get; set; }
        public decimal Weight { get; set; }
        public string Unit { get; set; }
        public string SerialCode { get; set; }
        public string Packing { get; set; }
        public decimal Amount { get; set; }
    }
}
