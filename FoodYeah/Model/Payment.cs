using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Payment
    {
        public uint paymentId { get; set; }

        public uint cardNumber { get; set; }    
        public Card card { get; set; }


    }
}


