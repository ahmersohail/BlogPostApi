using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogPostApi.Models;

namespace BlogPostApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity<Category>()
            //    .HasKey(c => c.Id);
            builder.Entity<Category>().Property(c => c.Id)
                .IsRequired();
            builder.Entity<Category>().Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(250);
            builder.Entity<Category>()
                .HasMany(c => c.Posts)
                .WithOne(p => p.Category);

            //builder.Entity<Post>()
            //    .HasKey(c => c.Id);
            builder.Entity<Post>().Property(c => c.Id)
                .IsRequired();
            builder.Entity<Post>().Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Entity<Post>().Property(c => c.Content)
                .IsRequired();

        }
    }
}
