using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagement.Data
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }

    public enum TransactionType
    {
        BUY = 1,
        SELL
    }
}
