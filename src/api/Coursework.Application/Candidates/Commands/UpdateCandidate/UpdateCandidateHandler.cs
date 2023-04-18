using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateHandler : ICommandHandler<UpdateCandidateRequest, Candidate>
    {
        private readonly CoursworkContext _context;

        public UpdateCandidateHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Candidate> Handle(UpdateCandidateRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();
            var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (candidate is null)
                throw new Exception($"Candidate with Guid {command.GID} not found");

            candidate = mapper.UpdateCandidateCommandMapper(command);

            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate;
        }
    }
}
