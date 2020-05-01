using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class Costumer_CategoryConfig
    {
        public Costumer_CategoryConfig(EntityTypeBuilder<Costumer_Category> entityBuilder)
        {
            entityBuilder.Property(x => x.Costumer_CategoryId).IsRequired();
            entityBuilder.Property(x => x.Costumer_CategoryName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Costumer_CategoryDescription).IsRequired();
        }
    }
}
