using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTodo.Model
{
    public class Client
    {
        public int ClientId { get; set; }

        public string ClientNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Country_Id { get; set; }
        public Country Country { get; set; }

    }
}
