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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product_Category> Product_Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer_Category> Customer_Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new CardConfig(builder.Entity<Card>());
            new CustomerConfig(builder.Entity<Customer>());
            new OrderConfig(builder.Entity<Order>()); 
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new Product_CategoryConfig(builder.Entity<Product_Category>());
            new ProductConfig(builder.Entity<Product>());
            new Customer_CategoryConfig(builder.Entity<Customer_Category>());
        }
    }
}
