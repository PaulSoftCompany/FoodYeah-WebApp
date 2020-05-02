using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class CustomerConfig
    {
        public CustomerConfig(EntityTypeBuilder<Customer> entityBuilder)
        {
            entityBuilder.Property(x => x.CustomerId).IsRequired();            
            entityBuilder.Property(x => x.CustomerName).IsRequired();
            entityBuilder.Property(x => x.CustomerAge).IsRequired();
            entityBuilder
            .HasOne(x => x.Customer_Category)
            .WithMany(x => x.Customers)
            .HasForeignKey(x => x.Customer_CategoryId);
        }
    }
}        