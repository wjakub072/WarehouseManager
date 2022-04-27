using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManager.Models
{
    [Table("Documents", Schema = "WM")]
    internal class Document
    {
        [Key]
        public int Document_Id { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime IssueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ConfirmDate { get; set; }
        public byte Collective { get; set; }
        [NotMapped]
        public string CustomerName { get; set; }

        [NotMapped]
        public string IssueDateString => IssueDate.Date.ToString("dd-MM-yyyy");
        [NotMapped]
        public string ConfirmDateString => ConfirmDate?.Date.ToString("dd-MM-yyyy");
    }
}
