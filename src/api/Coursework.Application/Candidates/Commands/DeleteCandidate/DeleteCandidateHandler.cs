using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Candidates.Commands.DeleteCandidate
{
    public class DeleteCandidateHandler : ICommandHandler<DeleteCandidateRequest, Guid>
    {
        private readonly CoursworkContext _context;

        public DeleteCandidateHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Guid> Handle(DeleteCandidateRequest command, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (candidate is null)
                throw new Exception($"Candidate with Guid {command.GID} not found");

            _context.Candidates.Remove(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate.GID;
        }
    }
}
