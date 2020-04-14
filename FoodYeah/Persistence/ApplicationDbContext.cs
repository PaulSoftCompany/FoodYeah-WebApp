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

        public DbSet<Card> Cards { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product_Category> Product_categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Costumer_Category> Costumer_categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CardConfig(builder.Entity<Card>());
            new CostumerConfig(builder.Entity<Costumer>());
            new OrderConfig(builder.Entity<Order>()); 
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new PaymentConfig(builder.Entity<Payment>());
            new Product_CategoryConfig(builder.Entity<Product_Category>());
            new ProductConfig(builder.Entity<Product>());
            new Costumer_CategoryConfig(builder.Entity<Costumer_Category>());

        }
    }
}
