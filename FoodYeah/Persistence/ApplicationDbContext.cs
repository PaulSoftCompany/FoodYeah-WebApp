using Microsoft.EntityFrameworkCore;
using FoodYeah.Model;
using FoodYeah.Persistence.Config;

namespace FoodYeah.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Card> cards { get; set; }
        public DbSet<Costumer> costumers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Product_Category> product_categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Costumer_Category> costumer_categories { get; set; }

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
