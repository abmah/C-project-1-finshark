using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>()
                .HasOne(p => p.AppUser)
                .WithMany(a => a.Portfolios)
                .HasForeignKey(p => p.AppUserId);


            builder.Entity<Portfolio>()
                .HasOne(p => p.Stock)
                .WithMany(a => a.Portfolios)
                .HasForeignKey(p => p.StockId);

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                 new IdentityRole {
                    Name = "User",
                    NormalizedName = "USER"
                },

            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
