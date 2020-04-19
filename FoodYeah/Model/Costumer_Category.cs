using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Costumer_Category
    {
        public int Costumer_CategoryId { get; set; }
        public List<Costumer> Costumers { get; set; }
        [Required]
        public string Costumer_CategoryName { get; set; }
        public string Costumer_CategoryDescription { get; set; }
    }
}
