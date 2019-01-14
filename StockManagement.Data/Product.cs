using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagement.Data
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }       
        public DateTime CreatedAt { get; set; }        
        public string CreatedBy { get; set; }
        public int CompanyId { get; set; }        
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
    }
}
