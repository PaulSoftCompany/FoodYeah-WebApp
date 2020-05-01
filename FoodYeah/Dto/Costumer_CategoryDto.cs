using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Dto
{
    public class Costumer_CategoryCreateDto
    {
        public string Costumer_CategoryName { get; set; }
        public string Costumer_CategoryDescription { get; set; }
    }

    public class Costumer_CategoryUpdateDto
    {
        public string Costumer_CategoryName { get; set; }
        public string Costumer_CategoryDescription { get; set; }
    }

    public class Costumer_CategoryDto
    {
        public int Costumer_CategoryId { get; set; }
        [Required]
        public List<CostumerDto> Costumers { get; set; }
        public string Costumer_CategoryName { get; set; }
        public string Costumer_CategoryDescription { get; set; }
    }
}