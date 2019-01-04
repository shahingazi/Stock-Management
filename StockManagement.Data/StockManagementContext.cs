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
        public DbSet<Company> Companies { get; set; }
        public DbSet<Barcode> Barcodes { get; set; }
        public DbSet<UserAccessRight> UserAccessRights { get; set; }
        public DbSet<Balance> Balances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Barcode>()
              .HasIndex(u => u.Code)
              .IsUnique();

            builder.Entity<Company>()
             .HasIndex(u => u.Name)
             .IsUnique();

        }

    }
}
