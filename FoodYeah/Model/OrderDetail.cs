using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class OrderDetail
    {
        public uint OrderDetailId { get; set; }

        public uint OrderId { get; set; }
        public Order Order { get; set; }

        public uint ProductId { get; set; }
        public Product Product { get; set; }

        public string Time { get; set; }
        public DateTime Date { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
