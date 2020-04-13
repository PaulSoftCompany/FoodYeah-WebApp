﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTodo.Model
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public List<Client> Clients { get; set; }

    }
}
