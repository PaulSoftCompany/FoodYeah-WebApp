using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTodo.Dto
{
    public class ClientCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string ClientNumber { get; set; }
        public int Country_Id { get; set; }
    }

    public class ClientUpdateDto
    {
        [Required]
        public string Name { get; set; }
        public string ClientNumber { get; set; }
        public int Country_Id { get; set; }
    }

    public class ClientDto
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string ClientNumber { get; set; }
        public string CountryName { get; set; }
    }
}
