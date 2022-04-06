namespace WarehouseManager.Models
{
    internal class Address
    {
        public int Address_Id { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string IsDefault { get; set; }
    }
}
