﻿using System.Collections.Generic;

namespace FoodYeah.Dto
{
    public class OrderCreateDto
    {
        public List<OrderDetailCreateDto> OrderDetails { get; set; }
        public int CustomerId { get; set; }
    }

    public class OrderDetailCreateDto
    {
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class OrderDto
    {
        public int OrderId { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; }

        public int CustomerId { get; set; }
        public CustomerDto Customer { get; set; }
        
        public string Date { get; set; }
        public string Time { get; set; }
        public byte TotalPrice { get; set; }
        public string Status { get; set; }
    }

    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }
        public OrderDto Order { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }


        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
