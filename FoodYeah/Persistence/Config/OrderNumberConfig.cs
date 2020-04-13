﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Model;

namespace FoodYeah.Persistence.Config
{
    public class OrderNumberConfig
    {
        public OrderNumberConfig(EntityTypeBuilder<OrderNumber> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Year);

            entityBuilder.HasData(new OrderNumber
            {
                Year = DateTime.Now.Year,
                Value = 0
            });
        }
    }
}
