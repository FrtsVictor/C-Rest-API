using Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd()
               .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Username)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("username")
                .HasColumnType("VARCHAR(30)");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(120)
                .HasColumnName("email")
                .HasColumnType("VARCHAR(120)");

            builder.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(80)");
        }
    }
}