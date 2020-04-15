using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class CostumerConfig
    {
        public CostumerConfig(EntityTypeBuilder<Costumer> entityBuilder)
        {
            entityBuilder.Property(x => x.CostumerId).IsRequired();            
            entityBuilder.Property(x => x.CostumerName).IsRequired();
            entityBuilder.Property(x => x.CostumerAge).IsRequired();
        }
    }
}        