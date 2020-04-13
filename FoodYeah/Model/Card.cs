using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Card
    {
        public uint cardId { get; set; }
        public bool cardType { get; set; }
        public byte cardCvi  { get; set; }
        [Required]
        public string cardOwnerName { get; set; }
        public DateTime cardExpireDate { get; set; }
    }
}
