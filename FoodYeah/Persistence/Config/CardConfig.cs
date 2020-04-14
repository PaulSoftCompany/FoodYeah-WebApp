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
            entityBuilder.Property(x => x.CardId).IsRequired();
            entityBuilder.Property(x => x.CardType).IsRequired();
            entityBuilder.Property(x => x.CardCvi).IsRequired();
            entityBuilder.Property(x => x.CardOwnerName).IsRequired();
            entityBuilder.Property(x => x.CardExpireDate).IsRequired();
        }
        //Chapas los atributos y los pones dentro del lambda y lo dejas ahí nomás
        //falta en todos los otros config?
    }
}
