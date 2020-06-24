﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Dto
{
    public class CustomerCreateDto
    {
        [Required]
        public string CustomerName { get; set; }
        public byte CustomerAge { get; set; }
        public int Customer_CategoryId { get; set; }
    }

    public class CustomerUpdateDto
    {
        [Required]
        public string CustomerName { get; set; }
        public byte CustomerAge { get; set; }
        public int Customer_CategoryId { get; set; }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public byte CustomerAge { get; set; }
        public Customer_CategoryDto Customer_Category { get; set; }
        public List<CardDto> Cards { get; set; } 
        public List<OrderDto> Orders {get; set;}
    }

    public class CustomerSimpleDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public byte CustomerAge { get; set; }
        public int Customer_CategoryId { get; set; }
    }
}
