using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Model;

namespace WebApiTodo.Persistence.Config
{
    public class SaleConfig
    {
        public SaleConfig(EntityTypeBuilder<Sale> entityBuilder)
        {
            entityBuilder.HasKey(x => new
            {
                x.Year,
                x.Month
            });
        }
    }
}
