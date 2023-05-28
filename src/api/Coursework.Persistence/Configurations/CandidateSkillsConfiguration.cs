using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coursework.Persistence.Configurations
{
    public class CandidateSkillsConfiguration : IEntityTypeConfiguration<CandidateSkill>
    {
        public void Configure(EntityTypeBuilder<CandidateSkill> builder)
        {
            builder.HasKey(e => new { e.CandidateGID, e.SkillGID });

            builder.HasOne(d => d.Skill)
                .WithMany()
                .HasForeignKey(d => d.SkillGID)
                .HasConstraintName("FK_CandidateSkills_SkillGID");

            builder.HasOne(d => d.Candidate)
                .WithMany()
                .HasForeignKey(d => d.CandidateGID)
                .HasConstraintName("FK_CandidateSkills_CandidateGID");
        }
    }
}
