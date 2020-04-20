using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//sigues ahi?
//no :v
namespace FoodYeah.Model
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public int CardNumber { get; set; }
        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public bool CardType { get; set; }
        public byte CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public string CardExpireDate { get; set; }

    }
}
