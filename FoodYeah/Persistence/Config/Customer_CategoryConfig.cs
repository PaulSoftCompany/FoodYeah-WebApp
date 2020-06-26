using FoodYeah.Commons;
using FoodYeah.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace FoodYeah.Persistence.Config
{
    public class Customer_CategoryConfig
    {
        public Customer_CategoryConfig(EntityTypeBuilder<Customer_Category> entityBuilder)
        {
            entityBuilder.Property(x => x.Customer_CategoryId).IsRequired();
            entityBuilder.Property(x => x.Customer_CategoryName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Customer_CategoryDescription).IsRequired();
            entityBuilder.HasData(
                new Customer_Category
                {
                    Customer_CategoryId = 1,
                    Customers = new List<Customer>(),
                    Customer_CategoryName = RoleHelper.Admin,
                    Customer_CategoryDescription = RoleHelper.Admin

                },
                new Customer_Category
                {
                    Customer_CategoryId = 2,
                    Customers = new List<Customer>(),
                    Customer_CategoryName = RoleHelper.User,
                    Customer_CategoryDescription = RoleHelper.User
                }
                );
        }
    }
}
