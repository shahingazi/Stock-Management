using Microsoft.EntityFrameworkCore;

namespace StockManagement.Data
{
    public class StockManagementContext : DbContext
    {
        public StockManagementContext(DbContextOptions<StockManagementContext> options)
                : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
