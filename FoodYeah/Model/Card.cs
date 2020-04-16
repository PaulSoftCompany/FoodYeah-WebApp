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
        public uint CardNumber { get; set; }
        public uint CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public bool CardType { get; set; }
        public byte CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public DateTime CardExpireDate { get; set; }

    }
}
