using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTodo.Model
{
    public class Sale
    {
        public int Year { get; set; }
        public int Month { get; set; }

        //Properties Calculate Report
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
