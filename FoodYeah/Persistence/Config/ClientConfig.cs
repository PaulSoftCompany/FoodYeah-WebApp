using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Model;

namespace FoodYeah.Persistence.Config
{
    public class ClientConfig
    {
        public ClientConfig(EntityTypeBuilder<Client> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.ClientNumber).IsRequired().HasMaxLength(30);

            entityBuilder.HasOne(x => x.Country)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.Country_Id);


            entityBuilder.HasData(
                new Client
                {
                    ClientId = 1,
                    ClientNumber = "1000000001",
                    Name = "Henry Antonio Mendoza Puerta"
                },
                new Client
                {
                    ClientId = 2,
                    ClientNumber = "1000000002",
                    Name = "Juan Perez Mendez"
                }
             );
        }
    }
}
