using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Costumer
    {
        public uint costumerId { get; set; }
        
        public List<Costumer_Category> costumer_Categories { get; set; }
        public List<Card> cards { get; set; } 
        public List<Order> orders {get; set;}
        [Required]
        public string costumerName { get; set; }
        public byte costumerAge { get; set; }
    }
}
