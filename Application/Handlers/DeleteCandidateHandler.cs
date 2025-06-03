using MediatR;
using RecruitmentApp.Application.Commands;
using RecruitmentApp.Domain.Interfaces;

namespace RecruitmentApp.Application.Handlers
{
    public class DeleteCandidateHandler : IRequestHandler<DeleteCandidateCommand, bool>
    {
        private readonly ICandidateRepository _repository;

        public DeleteCandidateHandler(ICandidateRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetByIdAsync(request.Id);
            if (candidate == null)
            {
                return false;
            }

            await _repository.DeleteAsync(candidate.Id);
            await _repository.SaveChangesAsync();

            return true;
        }
    }
}