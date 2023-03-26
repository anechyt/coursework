using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coursework.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.GID);

            builder.Property(e => e.Email).HasMaxLength(50);

            builder.Property(e => e.Password).HasMaxLength(100);

            builder.Property(e => e.Role).HasMaxLength(20);
        }
    }
}
