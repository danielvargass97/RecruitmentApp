using MediatR;
using RecruitmentApp.Application.DTOs;
using RecruitmentApp.Application.Commands;
using RecruitmentApp.Domain.Interfaces;
using RecruitmentApp.Domain.Entities;

namespace RecruitmentApp.Application.Handlers
{
    public class CreateCandidateHandler : IRequestHandler<CreateCandidateCommand, CandidateItemDto>
    {
        private readonly ICandidateRepository _repository;

        public CreateCandidateHandler(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<CandidateItemDto> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var exists = await _repository.GetByEmailAsync(request.Email);
            if (exists)
            {
                throw new InvalidOperationException("A candidate with this email already exists.");
            }

            var candidate = new Candidate
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                BirthDate = request.BirthDate,
                InsertDate = DateTime.UtcNow,
                CandidateExperiences = request.Experiences?.Select(ce => new CandidateExperience
                {
                    Company = ce.Company,
                    Job = ce.Job,
                    Description = ce.Description,
                    Salary = ce.Salary,
                    BeginDate = ce.BeginDate,
                    EndDate = ce.EndDate,
                    InsertDate = DateTime.UtcNow
                }).ToList() ?? [],
            };

            await _repository.AddAsync(candidate);
            await _repository.SaveChangesAsync();
            
            return new CandidateItemDto
            {
                Id = candidate.Id,
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirthDate = candidate.BirthDate,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                CandidateExperiences = [.. candidate.CandidateExperiences.Select(ce => new CandidateExperienceDto
                {
                    Company = ce.Company,
                    Job = ce.Job,
                    Description = ce.Description,
                    Salary = ce.Salary,
                    BeginDate = ce.BeginDate,
                    EndDate = ce.EndDate,
                })],
            };
        }
    }
}