using MediatR;
using RecruitmentApp.Application.DTOs;

namespace RecruitmentApp.Application.Commands
{
    public record CreateCandidateCommand(string Name, string Surname, DateTime BirthDate, string Email, List<CandidateExperienceDto> Experiences) : IRequest<CandidateItemDto>;
}