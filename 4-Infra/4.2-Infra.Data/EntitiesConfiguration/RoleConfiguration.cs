using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restful.Login.Domain.Entities;

namespace Restful.Login.Infra.Data.EntitiesConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");

            builder.HasKey(r => r.Id);

            builder
                .Property(c => c.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(50)");

            builder
                .Ignore(c => c.Error);

            builder
                .Ignore(c => c.IsValid);
        }
    }
}
