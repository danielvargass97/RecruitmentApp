using MediatR;
using RecruitmentApp.Application.DTOs;
using RecruitmentApp.Application.Queries;
using RecruitmentApp.Domain.Interfaces;


namespace RecruitmentApp.Application.Handlers
{
    public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdQuery, CandidateItemDto?>
    {
        private readonly ICandidateRepository _repository;

        public GetCandidateByIdHandler(ICandidateRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<CandidateItemDto?> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByIdAsync(request.Id);
            if (candidate == null)
            {
                return null;
            }

            return new CandidateItemDto
            {
                Id = candidate.Id,
                Name = candidate.Name,
                Surname = candidate.Surname,
                BirthDate = candidate.BirthDate,
                Email = candidate.Email,
                InsertDate = candidate.InsertDate,
                ModifyDate = candidate.ModifyDate,
                CandidateExperiences = candidate.CandidateExperiences.Select(ce => new CandidateExperienceDto
                {
                    Company = ce.Company,
                    Job = ce.Job,
                    Description = ce.Description,
                    Salary = ce.Salary,
                    BeginDate = ce.BeginDate,
                    EndDate = ce.EndDate,
                }).ToList()
            };
        }
    }
}