﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public int Age { get; set; }

        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
