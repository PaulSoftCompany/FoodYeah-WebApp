﻿// <auto-generated />
using System.Collections.Generic;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodYeah.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("FoodYeah.Model.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CardCvi")
                        .HasColumnType("integer");

                    b.Property<string>("CardExpireDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("CardOwnerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("CardType")
                        .HasColumnType("boolean");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Money")
                        .HasColumnType("numeric");

                    b.HasKey("CardId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("FoodYeah.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte>("CustomerAge")
                        .HasColumnType("smallint");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Customer_CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("CustomerId");

                    b.HasIndex("Customer_CategoryId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("FoodYeah.Model.Customer_Category", b =>
                {
                    b.Property<int>("Customer_CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Customer_CategoryDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Customer_CategoryName")
                        .IsRequired()
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Customer_CategoryId");

                    b.ToTable("Customer_Categories");
                });

            modelBuilder.Entity("FoodYeah.Model.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InitTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("FoodYeah.Model.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<byte>("Quantity")
                        .HasColumnType("smallint");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FoodYeah.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("Ingredients")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("Product_CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("SellDay")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.HasIndex("Product_CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodYeah.Model.Product_Category", b =>
                {
                    b.Property<int>("Product_CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Product_CategoryDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Product_CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Product_CategoryId");

                    b.ToTable("Product_Categories");
                });

            modelBuilder.Entity("FoodYeah.Model.Card", b =>
                {
                    b.HasOne("FoodYeah.Model.Customer", "Customer")
                        .WithMany("Cards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodYeah.Model.Customer", b =>
                {
                    b.HasOne("FoodYeah.Model.Customer_Category", "Customer_Category")
                        .WithMany("Customers")
                        .HasForeignKey("Customer_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodYeah.Model.Order", b =>
                {
                    b.HasOne("FoodYeah.Model.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodYeah.Model.OrderDetail", b =>
                {
                    b.HasOne("FoodYeah.Model.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodYeah.Model.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodYeah.Model.Product", b =>
                {
                    b.HasOne("FoodYeah.Model.Product_Category", "Product_Category")
                        .WithMany("Products")
                        .HasForeignKey("Product_CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
