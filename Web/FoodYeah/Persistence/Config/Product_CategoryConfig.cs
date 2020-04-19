using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class Product_CategoryConfig
    {
        public Product_CategoryConfig(EntityTypeBuilder<Product_Category> entityBuilder)
        {
            entityBuilder.Property(x => x.Product_CategoryId).IsRequired();
            entityBuilder.Property(x => x.Product_CategoryName).IsRequired();
            entityBuilder.Property(x => x.Product_CategoryDescription).IsRequired();
        }
    }
}
