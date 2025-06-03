using MediatR;
using RecruitmentApp.Application.Commands;
using RecruitmentApp.Application.DTOs;
using RecruitmentApp.Domain.Entities;
using RecruitmentApp.Domain.Interfaces;

namespace RecruitmentApp.Application.Handlers
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateCommand, CandidateItemDto?>
    {
        private readonly ICandidateRepository _repository;

        public UpdateCandidateHandler(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<CandidateItemDto?> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByIdAsync(request.Id);
            if (candidate == null)
            {
                return null;
            }
            candidate.Name = request.Name;
            candidate.Surname = request.Surname;
            candidate.BirthDate = request.BirthDate;
            candidate.Email = request.Email;
            candidate.ModifyDate = DateTime.UtcNow;
            candidate.CandidateExperiences = request.Experiences?.Select(ce => new CandidateExperience
            {
                Company = ce.Company,
                Job = ce.Job,
                Description = ce.Description,
                Salary = ce.Salary,
                BeginDate = ce.BeginDate,
                EndDate = ce.EndDate,
                ModifyDate = DateTime.UtcNow
            }).ToList() ?? [];

            await _repository.SaveChangesAsync();

            return new CandidateItemDto
            {
                Id = candidate.Id,
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirthDate = candidate.BirthDate,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate,
                CandidateExperiences = [.. candidate.CandidateExperiences.Select(ce => new CandidateExperienceDto
                {
                    Company = ce.Company,
                    Job = ce.Job,
                    Description = ce.Description,
                    Salary = ce.Salary,
                    BeginDate = ce.BeginDate,
                    EndDate = ce.EndDate,
                })]
            };
        }
    }
}