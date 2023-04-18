using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;

namespace Coursework.Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateHandler : ICommandHandler<CreateCandidateRequest, Candidate>
    {
        private readonly CoursworkContext _context;

        public CreateCandidateHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Candidate> Handle(CreateCandidateRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();

            var candidate = mapper.CreateCandidateCommandMapper(command);

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate;
        }
    }
}
