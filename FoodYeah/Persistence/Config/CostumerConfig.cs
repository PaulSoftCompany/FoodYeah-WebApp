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

            //Vente a orderconfig tu vente a orderconfig

            entityBuilder.Property(x => x.CostumerId).IsRequired();            
            entityBuilder.Property(x => x.CostumerName).IsRequired();
            entityBuilder.Property(x => x.CostumerAge).IsRequired();
        }
    }
}
//https://www.entityframeworktutorial.net/efcore/configure-one-to-one-relationship-using-fluent-api-in-ef-core.aspx
//https://www.learnentityframeworkcore.com/configuration/one-to-one-relationship-configuration          