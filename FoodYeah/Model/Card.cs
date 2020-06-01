using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Model
{
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public bool CardType { get; set; }
        public int CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public int CardExpireMonth{ get; set; }
        public int CardExpireYear { get; set; }

    }
}
