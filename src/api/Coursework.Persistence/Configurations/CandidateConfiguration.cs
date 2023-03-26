using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coursework.Persistence.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(e => e.GID);

            builder.Property(e => e.FirstName).HasMaxLength(50);

            builder.Property(e => e.LastName).HasMaxLength(50);

            builder.Property(e => e.PhoneNumber).HasMaxLength(50);

            builder.HasOne(d => d.User)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.UserGID)
                    .HasConstraintName("FK_Candidates_UserGID");
        }
    }
}
