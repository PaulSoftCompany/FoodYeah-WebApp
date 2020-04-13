using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTodo.Model
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }

        public List<WarehouseProduct> Products { get; set; }
    }
}
