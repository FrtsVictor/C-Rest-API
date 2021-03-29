using Domain.API.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

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

             builder.Property(x=>x.IsActive)
                .HasColumnName("isActive")
                .HasColumnType("BOOLEAN");

            builder.Property(x=>x.CreatedDate)
                .HasColumnName("createedDate")
                .HasColumnType("DATE");
        }
    }
}