﻿namespace WarehouseManager.Models
{
    internal class Element
    {
        public int ELement_Id { get; set; }
        public int DeliveryId { get; set; }
        public int PackageId { get; set; }
        public bool Insured { get; set; }
        public decimal Value { get; set; }
        public decimal Weight { get; set; }
        public string Unit { get; set; }
        public string SerialCode { get; set; }
        public bool Damaged { get; set; }
        public decimal Amount { get; set; }
    }
}