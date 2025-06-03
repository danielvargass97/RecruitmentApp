using MediatR;
using RecruitmentApp.Application.DTOs;
using RecruitmentApp.Application.Queries;
using RecruitmentApp.Domain.Interfaces;

namespace RecruitmentApp.Application.Handlers
{
    public class GetAllCandidatesHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateItemDto>>
    {
        private readonly ICandidateRepository _repository;

        public GetAllCandidatesHandler(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CandidateItemDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _repository.GetAllAsync();
            return candidates.Select(c => new CandidateItemDto
            {
                Id = c.Id,
                Name = c.Name,
                Surname = c.Surname,
                BirthDate = c.BirthDate,
                Email = c.Email,
                InsertDate = c.InsertDate,
                ModifyDate = c.ModifyDate,
                CandidateExperiences = [.. c.CandidateExperiences.Select(ce => new CandidateExperienceDto
                {
                    Company = ce.Company,
                    Job = ce.Job,
                    Description = ce.Description,
                    Salary = ce.Salary,
                    BeginDate = ce.BeginDate,
                    EndDate = ce.EndDate,
                })]
            });
        }
    }

}