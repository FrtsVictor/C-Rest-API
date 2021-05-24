using Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Context.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("courses");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("description")
                .HasColumnType("VARCHAR(200)");

            builder.Property(p => p.Category)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("category")
                .HasColumnType("VARCHAR(50)");

            builder.HasOne(p => p.User)
                .WithMany().HasForeignKey(fk => fk.UserId);
        }
    }
}