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
        { }
        //dbSet=users table
        public virtual DbSet<User> Users{ get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }

    }
}