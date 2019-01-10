using StockManagement.Data;

namespace StockManagement.Dtos
{
    public class MyAccessRight
    {
        public int CompanyId { get; set; }
        public AccessRight Role { get; set; }
    }
}
