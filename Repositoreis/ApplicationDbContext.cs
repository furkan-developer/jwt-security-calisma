using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWT_Security.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JWT_Security.Repositoreis
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public ApplicationDbContext(DbContextOptions options)
           : base(options)
        {
        }
        
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        }
    }
}