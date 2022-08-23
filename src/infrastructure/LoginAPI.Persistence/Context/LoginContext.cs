using LoginAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Persistence.Context
{
    public class LoginContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tokens> Tokens { get; set; }

        public LoginContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LoginContext).Assembly);
        }
    }
}