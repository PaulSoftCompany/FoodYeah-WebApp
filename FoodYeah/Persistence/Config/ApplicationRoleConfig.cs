using FoodYeah.Model.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Persistence.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
           
            entityBuilder.HasMany(x => x.UserRoles).WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId).IsRequired();

            entityBuilder.HasData(
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"

                },
                 new ApplicationRole
                 {
                     Id = Guid.NewGuid().ToString(),
                     Name = "User",
                     NormalizedName = "USER"

                 }
                );
        }

    }
}
