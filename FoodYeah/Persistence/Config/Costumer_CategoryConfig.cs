using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class Costumer_CategoryConfig
    {
        public Costumer_CategoryConfig(EntityTypeBuilder<Costumer_Category> entityBuilder)
        {
            entityBuilder.Property(x => x.Costumer_categoryId).IsRequired();
            entityBuilder.Property(x => x.Costumer_categoryName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Card_Counter).IsRequired();
        }
    }
}
