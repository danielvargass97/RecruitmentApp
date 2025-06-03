using MediatR;
using RecruitmentApp.Application.DTOs;

namespace RecruitmentApp.Application.Queries
{
    public record GetCandidateByIdQuery(int Id) : IRequest<CandidateItemDto>;
}