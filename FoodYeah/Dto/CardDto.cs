using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Dto
{
    public class CardCreateDto
    {
        [Required]
        public string CardNumber { get; set; }
        public int CustomerId { get; set; }
        public bool CardType { get; set; }
        public byte CardCvi  { get; set; }
        public int CardExpireYear { get; set; }
        public int CardExpireMonth { get; set; }
    }

    public class CardUpdateDto
    {
        public string CardOwnerName { get; set; }
    }

    public class CardDto
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        public bool CardType { get; set; }
        public int CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public int CardExpireYear { get; set; }
        public int CardExpireMonth { get; set; }
    }

     public class CardSimpleDto
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public int CustomerId { get; set; }
        public bool CardType { get; set; }
        public int CardCvi  { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        public int CardExpireYear { get; set; }
        public int CardExpireMonth { get; set; }
    }
}
