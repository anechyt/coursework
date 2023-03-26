using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coursework.Persistence.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.HasKey(e => e.GID);

            builder.Property(e => e.FirstName).HasMaxLength(50);

            builder.Property(e => e.LastName).HasMaxLength(50);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Recruiters)
                .HasForeignKey(d => d.UserGID)
                .HasConstraintName("FK_Recruiters_UserGID");
        }
    }
}
