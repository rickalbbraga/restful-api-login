using Domain.Entities;
using Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class UserRegisterContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserRegisterContext(DbContextOptions<UserRegisterContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}