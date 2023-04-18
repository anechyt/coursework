using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Recruiters.Commands.UpdateRecruiter
{
    public class UpdateRecruiterHandler : ICommandHandler<UpdateRecruiterRequest, Recruiter>
    {
        private readonly CoursworkContext _context;

        public UpdateRecruiterHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Recruiter> Handle(UpdateRecruiterRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();
            var recruiter = await _context.Recruiters.FirstOrDefaultAsync(x => x.GID == command.GID);

            if (recruiter is null)
                throw new Exception($"Recruiter with Guid {command.GID} not found");

            recruiter = mapper.UpdateRecruiterCommandMapper(command);

            _context.Recruiters.Update(recruiter);
            await _context.SaveChangesAsync(cancellationToken);

            return recruiter;
        }
    }
}
