using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser>
    {
         public ApplicationDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
         {
            
         }

         public DbSet<Stock> Stocks { get; set; }

         public DbSet<Comment> Comments { get; set; }
    }
}