using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder
                .Property(u => u.Id)
                .HasColumnName("id")
                .IsRequired();
            
            builder
                .Property(u => u.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)");

            builder
                .Property(u => u.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(50)");

            builder
                .Property(u => u.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)");

            builder
                .Property(u => u.ConfirmEmail)
                .HasColumnName("confirm_email")
                .HasColumnType("varchar(50)");

            builder
                .Property(u => u.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(150)");

            builder
                .Property(u => u.ConfirmPassword)
                .HasColumnName("confirm_password")
                .HasColumnType("varchar(150)");
            
            builder
                .Property(u => u.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("date");

            builder
                .Property(u => u.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("date");
        }
    }
}