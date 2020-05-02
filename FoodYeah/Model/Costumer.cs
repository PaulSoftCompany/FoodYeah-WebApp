using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Model
{
    public class Costumer
    {
        public int CostumerId { get; set; }
        public int Costumer_CategoryId { get; set; }
        public Costumer_Category Costumer_Category { get; set; }
        public List<Card> Cards { get; set; } 
        public List<Order> Orders {get; set;}

        [Required]
        public string CostumerName { get; set; }
        public byte CostumerAge { get; set; }
    }
}
