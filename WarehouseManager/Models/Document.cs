using System;

namespace WarehouseManager.Models
{
    internal class Document
    {
        public int Document_Id { get; set; }
        public int CustomerId { get; set; }
        public short Type { get; set; }
        public string Code { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ConfirmDate { get; set; }
        public bool Collective { get; set; }
    }
}
