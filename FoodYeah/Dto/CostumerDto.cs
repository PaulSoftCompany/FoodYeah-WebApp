using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Dto
{
    public class CostumerCreateDto
    {
        [Required]
        public string CostumerName { get; set; }
        public byte CostumerAge { get; set; }
        public int Costumer_CategoryId { get; set; }
    }

    public class CostumerUpdateDto
    {
        [Required]
        public string CostumerName { get; set; }
        public byte CostumerAge { get; set; }
    }

    public class CostumerDto
    {
        public int CostumerId { get; set; }
        public string CostumerName { get; set; }
        public byte CostumerAge { get; set; }
    }
}
