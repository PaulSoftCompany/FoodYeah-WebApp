using Microsoft.EntityFrameworkCore;
using WebApiTodo.Model;
using WebApiTodo.Persistence.Config;

namespace WebApiTodo.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderNumber> OrderNumbers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new ClientConfig(builder.Entity<Client>());
            new OrderConfig(builder.Entity<Order>());
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new ProductConfig(builder.Entity<Product>());
            new OrderNumberConfig(builder.Entity<OrderNumber>());
            new SaleConfig(builder.Entity<Sale>());
            new CountryConfig(builder.Entity<Country>());
            new WarehouseConfig(builder.Entity<Warehouse>());
        }
    }
}
