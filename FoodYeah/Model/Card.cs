using System.ComponentModel.DataAnnotations;

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
