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
        public string costumerName { get; set; }
        public byte costumerAge { get; set; }
    }

    public class CostumerUpdateDto
    {
        [Required]
        public string costumerName { get; set; }
        public byte costumerAge { get; set; }
    }

    public class CostumerDto
    {
        public uint costumerId { get; set; }
        public string costumerName { get; set; }
        public byte costumerAge { get; set; }
    }
}
