﻿// <auto-generated />
using AzureFunction.Challenge.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AzureFunction.Challenge.Persistence.Migrations
{
    [DbContext(typeof(AzureFunctionDbContext))]
    [Migration("20240722182535_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("AzureFunction.Challenge.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Delicious beef burger",
                            Name = "ByteBurger",
                            Price = 5.99m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Bits of fries",
                            Name = "BitFries",
                            Price = 1.99m
                        },
                        new
                        {
                            Id = 3,
                            Description = "A small hashbrown",
                            Name = "HashBrown",
                            Price = 0.99m
                        },
                        new
                        {
                            Id = 4,
                            Description = "A cold glass of cola",
                            Name = "ClassCola",
                            Price = 1.50m
                        },
                        new
                        {
                            Id = 5,
                            Description = "A giant milkshake",
                            Name = "StackShake",
                            Price = 3.50m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
