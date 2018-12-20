using System.ComponentModel.DataAnnotations.Schema;

namespace StockManagement.Data
{
    public class Barcode
    {
        public int Id { get; set; }       
        public string Code { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
