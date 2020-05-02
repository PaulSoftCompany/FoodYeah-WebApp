using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class Customer_CategoryConfig
    {
        public Customer_CategoryConfig(EntityTypeBuilder<Customer_Category> entityBuilder)
        {
            entityBuilder.Property(x => x.Customer_CategoryId).IsRequired();
            entityBuilder.Property(x => x.Customer_CategoryName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Customer_CategoryDescription).IsRequired();
        }
    }
}
