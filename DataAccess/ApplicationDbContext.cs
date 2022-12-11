using DataAccess.Entities;
using Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Cart>? Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    CreatedTime = DateTime.Now,
                    CreatedUserId = 1
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 2,
                    Name = "User",
                    CreatedTime = DateTime.Now,
                    CreatedUserId = 1
                });

            var salt = Encryption.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "AdminAdmin",
                    Username = "admin",
                    BirthDate = DateTime.UtcNow,
                    Email= "admin@gmail.com",
                    Salt = salt,
                    Hash = Encryption.GenerateHash("Admin", salt),
                    RoleId = 1,
                    CreatedTime = DateTime.UtcNow,
                    CreatedUserId = 1
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Book-1",
                    Price = 5,
                    ImagePath = "~/images/product/book-1.png",
                    About = "About",
                    CountOfPages= 2,
                    CreatedTime = DateTime.UtcNow,
                    CreatedUserId = 1
                });
        }
    }
}