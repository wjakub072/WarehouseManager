using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManager.Models
{
    [Table("Customers", Schema ="WM")]
    internal class Customer
    {
        [Key]
        public int Customer_Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string Origin { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public byte Status { get; set; }
    }
}
