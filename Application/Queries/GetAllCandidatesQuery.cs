using MediatR;
using RecruitmentApp.Application.DTOs;


namespace RecruitmentApp.Application.Queries
{
    public record GetAllCandidatesQuery : IRequest<IEnumerable<CandidateItemDto>>;
}