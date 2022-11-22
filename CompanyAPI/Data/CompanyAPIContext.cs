using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Models;
using System.Reflection.Metadata;

namespace CompanyAPI.Data
{
    public class CompanyAPIContext : DbContext
    {
        public CompanyAPIContext (DbContextOptions<CompanyAPIContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
            .HasMany(c => c.Students)
             .WithOne(e => e.Course);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
