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
            entityBuilder.Property(x => x.CostumerId).IsRequired();
            entityBuilder.Property(x => x.PaymentId).IsRequired();
            //->esta linea ya no es necesaria //entityBuilder.HasOne(x => x.Payment).WithOne(x => x.Order).HasForeignKey<Order>(x => x.PaymentId);//relacion 1 a 1 con Payment
            entityBuilder.HasOne(x => x.Costumer).WithMany(x => x.Orders).HasForeignKey(x => x.CostumerId);//relacion 1 a muchos con Costumer
        }
    }
}
