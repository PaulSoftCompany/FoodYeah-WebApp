using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodYeah.Persistence.Config
{
    public class CostumerConfig
    {
        public CostumerConfig(EntityTypeBuilder<Costumer> entityBuilder)
        {
            entityBuilder.Property(x => x.CostumerId).IsRequired();            
            entityBuilder.Property(x => x.CostumerName).IsRequired();
            entityBuilder.Property(x => x.CostumerAge).IsRequired();
            entityBuilder.HasOne(x => x.Costumer_Category).WithMany(x => x.Costumers).HasForeignKey(x => x.Costumer_CategoryId);
        }
    }
}        