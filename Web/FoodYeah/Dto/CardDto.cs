using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Model;

namespace FoodYeah.Dto
{
    public class CardCreateDto
    {
        [Required]
        public int CardNumber { get; set; }
        public int CostumerId { get; set; }
        public bool CardType { get; set; }
        public byte CardCvi  { get; set; }
        public string CardExpireDate { get; set; }
    }

    public class CardUpdateDto
    {
        public string CardOwnerName { get; set; }
    }

    public class CardDto
    {
        public int CardNumber { get; set; }
        public int CostumerId { get; set; }
        public CostumerDto Costumer { get; set; }
        public bool CardType { get; set; }
        public byte CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public string CardExpireDate { get; set; }
    }
}
