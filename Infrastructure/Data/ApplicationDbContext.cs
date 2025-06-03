using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Domain.Entities;

namespace RecruitmentApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<CandidateExperience> CandidateExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Candidate>()
                .HasMany(c => c.CandidateExperiences)
                .WithOne(ce => ce.Candidate)
                .HasForeignKey(ce => ce.CandidateId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CandidateExperience>()
                .HasOne(e => e.Candidate)
                .WithMany(c => c.CandidateExperiences)
                .HasForeignKey(e => e.CandidateId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
