using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class CardConfig
    {
        public CardConfig(EntityTypeBuilder<Card> entityBuilder)
        {
            entityBuilder.HasKey(x => x.CardNumber);
            entityBuilder.Property(x => x.CardNumber).IsRequired();
            entityBuilder.Property(x => x.CardType).IsRequired();
            entityBuilder.Property(x => x.CardCvi).IsRequired();
            entityBuilder.Property(x => x.CardOwnerName).IsRequired();
            entityBuilder.Property(x => x.CardExpireDate).IsRequired();
            entityBuilder.HasOne(x => x.Costumer).WithMany(x => x.Cards).HasForeignKey(x => x.CostumerId); 
        }
    }
}
