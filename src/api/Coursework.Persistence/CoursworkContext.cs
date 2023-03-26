using Coursework.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Persistence
{
    public class CoursworkContext : DbContext
    {
        public CoursworkContext(DbContextOptions<CoursworkContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        public virtual DbSet<Candidate> Candidates { get; set; } = null!;

        public virtual DbSet<Recruiter> Recruiters { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
