using System.IO;
using Infra.Context.Mappings;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Context
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext() {}
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options) { }
        public CourseDbContext(DbContextOptionsBuilder<CourseDbContext> optionsBuilder) { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=UserAPI;User Id=postgres;Password=123321");
        }
    }
}
