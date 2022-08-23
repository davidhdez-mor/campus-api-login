using LoginAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginAPI.Persistence.EntityConfiguration
{
    public class TokenConfiguration : IEntityTypeConfiguration<Tokens>
    {
        public void Configure(EntityTypeBuilder<Tokens> builder)
        {
            builder.HasKey(tokens => tokens.Id);
            builder.Property(tokens => tokens.Id)
                .ValueGeneratedOnAdd();

            builder.Property(tokens => tokens.Token)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
        }
    }
}