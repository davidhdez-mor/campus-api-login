using LoginAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginAPI.Persistence.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);
            builder.HasIndex(user => user.Username)
                .IsUnique();

            builder.Property(user => user.Id)
                .ValueGeneratedOnAdd();

            builder.Property(user => user.Username)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            builder.Property(user => user.Password)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            builder.HasMany(user => user.Roles);
        }
    }
}