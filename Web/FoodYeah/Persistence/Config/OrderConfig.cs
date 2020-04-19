using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class OrderConfig
    {
        public OrderConfig(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.Property(x => x.OrderId).IsRequired();
            entityBuilder.HasOne(x => x.Costumer).WithMany(x => x.Orders).HasForeignKey(x => x.CostumerId);
            //entityBuilder.HasOne(x => x.Card).WithMany(x => x.Orders).HasForeignKey(x => x.CardNumber); 
            entityBuilder.Property(x => x.Date).IsRequired();
            entityBuilder.Property(x => x.Time).IsRequired();
            entityBuilder.Property(x => x.TotalPrice).IsRequired();
        }
    }
}
