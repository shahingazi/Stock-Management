using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagement.Data
{
    public class Balance
    {
        public int Id { get; set; }        
        public int StockQuantity { get; set; }
        public int TotalQuantity { get; set; }
        public int PurchaseAmount { get; set; }
        public int SellingAmount { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

    }
}
