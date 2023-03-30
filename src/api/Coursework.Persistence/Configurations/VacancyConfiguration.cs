using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coursework.Persistence.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(e => e.GID);

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.VacancyStatus)
                .WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.VacancyStatusGID)
                .HasConstraintName("FK_Vacancies_VacancyStatusGID");

            builder.HasOne(d => d.Recruiter)
                .WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.RecruiterGID)
                .HasConstraintName("FK_Vacancies_RecruiterGID");
        }
    }
}
