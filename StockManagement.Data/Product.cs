using System;
using System.ComponentModel.DataAnnotations;

namespace StockManagement.Data
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        [Required]
        public DateTime CratedAt { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
