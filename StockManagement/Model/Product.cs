using System;

namespace StockManagement.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public DateTime CratedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
