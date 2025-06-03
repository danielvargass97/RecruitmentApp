using MediatR;

namespace RecruitmentApp.Application.Commands
{
    public record DeleteCandidateCommand(int Id) : IRequest<bool>;
}