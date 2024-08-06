using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Entities;

namespace Assignment.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Test1 Customer",
                    MobileNumber = "00441234567",
                    EmailAddress = "test1@gmail.com",
                    Age = 30,
                    ImageUrl = "https://placehold.co/600x400",
                },
                    new Customer
                    {
                        Id = 2,
                        Name = "Test2 Customer",
                        MobileNumber = "00441234568",
                        EmailAddress = "test2@gmail.com",
                        Age = 35,
                        ImageUrl = "https://placehold.co/600x401",
                    },
                    new Customer
                    {
                        Id = 3,
                        Name = "Test3 Customer",
                        MobileNumber = "00441234569",
                        EmailAddress = "test3@gmail.com",
                        Age = 40,
                        ImageUrl = "https://placehold.co/600x402",
                    });


            modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id = 1,
                CustomerId = 1,
                POBox = "B109AZ",
                FullAddress = "Test1 Address"
            },
            new Address
            {
                Id = 2,
                CustomerId = 1,
                POBox = "B099MM",
                FullAddress = "Test2 Address"
            },
            new Address
            {
                Id = 3,
                CustomerId = 1,
                POBox = "G108AP",
                FullAddress = "Test3 Address"
            }, new Address
            {
                Id = 4,
                CustomerId = 2,
                POBox = "E059AZ",
                FullAddress = "Test4 Address"
            },
            new Address
            {
                Id = 5,
                CustomerId = 2,
                POBox = "D079JA",
                FullAddress = "Test5 Address"
            },
            new Address
            {
                Id = 6,
                CustomerId = 3,
                POBox = "C028AP",
                FullAddress = "Test6 Address"
            });
        }
    }
}
