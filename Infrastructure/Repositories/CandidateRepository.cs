using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Domain.Entities;
using RecruitmentApp.Domain.Interfaces;
using RecruitmentApp.Infrastructure.Data;

namespace RecruitmentApp.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
        }

        public async Task DeleteAsync(int id)
        {
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
            }
        }

        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            return await _context.Candidates
                .Include(c => c.CandidateExperiences)
                .ToListAsync();
        }

        public async Task<Candidate?> GetByIdAsync(int id)
        {
            return await _context.Candidates
                .Include(c => c.CandidateExperiences)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task UpdateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> GetByEmailAsync(string email)
        {
            return _context.Candidates
                .AnyAsync(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
