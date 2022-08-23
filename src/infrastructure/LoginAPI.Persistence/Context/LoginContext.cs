using LoginAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Persistence.Context
{
    public class LoginContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public LoginContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoginContext).Assembly);
        }
    }
}