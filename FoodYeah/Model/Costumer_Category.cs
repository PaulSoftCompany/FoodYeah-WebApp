﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Costumer_Category
    {
        public uint Costumer_categoryId { get; set; }
        public List<Costumer> Costumers { get; set; }
        [Required]
        public string Costumer_categoryName { get; set; }
        public uint Card_Counter { get; set; }
    }
}
