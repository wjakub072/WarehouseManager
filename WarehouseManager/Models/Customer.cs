using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Models
{
    internal class Customer
    {
        public int Customer_Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string Origin { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
    }
}
