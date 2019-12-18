using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restful.Login.Infra.Data.EntitiesConfiguration
{
    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(c => c.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(c => c.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date")
                .IsRequired(false);

            builder
                .Ignore(c => c.Error);

            builder
                .Ignore(c => c.IsValid);
        }
    }
}
