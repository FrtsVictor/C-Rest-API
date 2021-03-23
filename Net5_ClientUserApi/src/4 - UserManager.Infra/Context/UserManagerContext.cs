using UserManager.Domain.Entities;
using UserManager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace UserManager.Infra.Context
{
    public class UserManagerContext : DbContext
    {
        public UserManagerContext()
        {}

        public UserManagerContext(DbContextOptions<UserManagerContext> options) : base(options)
        { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=UserAPI;User Id=postgres;Password=123321");
        }
        //dbSet=users table
        public virtual DbSet<User> Users{ get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }

    }
}