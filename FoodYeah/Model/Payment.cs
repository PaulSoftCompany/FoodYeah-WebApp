using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Payment
    {
        public uint PaymentId { get; set; }
        public Order Order { get; set; }
        public uint CardNumber { get; set; }    
        public Card Card { get; set; }

    }
}


