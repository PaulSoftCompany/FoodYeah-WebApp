using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class PaymentConfig
    {
        public PaymentConfig(EntityTypeBuilder<Payment> entityBuilder)
        {
            entityBuilder.Property(x => x.PaymentId).IsRequired();
            entityBuilder.Property(x => x.CardNumber).IsRequired();
        }
    }
}
