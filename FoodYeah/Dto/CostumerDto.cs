using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Model;

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
