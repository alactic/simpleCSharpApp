using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser>
    {
         public ApplicationDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
         {
            
         }

         public DbSet<Stock> Stocks { get; set; }

         public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "admin_concurrency_stamp"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "user_concurrency_stamp"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}