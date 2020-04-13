using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Model;

namespace WebApiTodo.Persistence.Config
{
    public class WarehouseConfig
    {
        public WarehouseConfig(EntityTypeBuilder<Warehouse> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            entityBuilder.HasData(
              new Warehouse
              {
                  WarehouseId = 1,
                  Name = "Zona A"
              },
              new Warehouse
              {
                  WarehouseId = 2,
                  Name = "Zona B"
              }
           );
        }
    }
}
