using UserManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace UserManager.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
       public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(x=>x.Id);


            builder.Property(x=>x.Id)
                .HasColumnType("BIGINT")
                .UseHiLo();

            builder.Property(x=>x.Name)
                .IsRequired()
                .HasMaxLength(75)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(75)");
            
            builder.Property(x=>x.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x=>x.Email)
                .IsRequired()
                .HasMaxLength(90)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(90)");

              builder.Property(x=>x.Username)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("username")
                .HasColumnType("VARCHAR(20)");
        }
    }
}