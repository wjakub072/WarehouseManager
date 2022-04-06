﻿namespace WarehouseManager.Models
{
    internal class Sector
    {
        public int Sector_Id { get; set; }
        public int WarehouseId { get; set; }
        public string Code { get; set; }
        public string Capacity { get; set; }
        public decimal Used { get; set; }
        public string Mostly { get; set; }
    }
}