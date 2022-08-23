using LoginAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginAPI.Persistence.EntityConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(role => role.Id);
            
            builder.Property(role => role.RoleName)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(20);
            
            builder.HasData(new Role()
            {
                Id = 1,
                RoleName = "admin"
            },
            new Role(){
                Id = 2,
                RoleName = "user"
            },
            new Role(){
                Id = 3,
                RoleName = "guest"
            });
            
        }
    }
}