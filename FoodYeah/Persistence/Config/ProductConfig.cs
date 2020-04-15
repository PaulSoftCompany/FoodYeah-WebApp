using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class ProductConfig
    {
        public ProductConfig(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.Property(x => x.ProductId).IsRequired();
            entityBuilder.Property(x => x.ProductName).IsRequired();
            entityBuilder.Property(x => x.ProductPrice).IsRequired();
        }
    }
}
