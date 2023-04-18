using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Recruiters.Commands.DeleteRecruiter
{
    public class DeleteRecruiterHandler : ICommandHandler<DeleteRecruiterRequest, Guid>
    {
        private readonly CoursworkContext _context;

        public DeleteRecruiterHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Guid> Handle(DeleteRecruiterRequest command, CancellationToken cancellationToken)
        {
            var recruiter = await _context.Recruiters.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (recruiter is null)
                throw new Exception($"Recruiter with Guid {command.GID} not found");

            _context.Recruiters.Remove(recruiter);
            await _context.SaveChangesAsync(cancellationToken);

            return command.GID;
        }
    }
}
