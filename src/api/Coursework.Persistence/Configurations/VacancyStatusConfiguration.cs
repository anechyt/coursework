using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coursework.Persistence.Configurations
{
    public class VacancyStatusConfiguration : IEntityTypeConfiguration<VacancyStatus>
    {
        public void Configure(EntityTypeBuilder<VacancyStatus> builder)
        {
            builder.HasKey(e => e.GID);

            builder.Property(e => e.Name).HasMaxLength(50);
        }
    }
}
