using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coursework.Persistence.Configurations
{
    public class VacancySkillsConfiguration : IEntityTypeConfiguration<VacancySkill>
    {
        public void Configure(EntityTypeBuilder<VacancySkill> builder)
        {
            builder.HasKey(e => new { e.VacancyGID, e.SkillGID });

            builder.HasOne(d => d.Skill)
                .WithMany()
                .HasForeignKey(d => d.SkillGID)
                .HasConstraintName("FK_VacancySkills_SkillGID");

            builder.HasOne(d => d.Vacancy)
                .WithMany()
                .HasForeignKey(d => d.VacancyGID)
                .HasConstraintName("FK_VacancySkills_VacancyGID");
        }
    }
}
