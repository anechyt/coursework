using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;

namespace Coursework.Application.Recruiters.Commands.CreateRecruiter
{
    public class CreateRecruiterHandler : ICommandHandler<CreateRecruiterRequest, Recruiter>
    {
        private readonly CoursworkContext _context;

        public CreateRecruiterHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Recruiter> Handle(CreateRecruiterRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();

            var recruiter = mapper.CreateRecruiterCommandMapper(command);

            _context.Recruiters.Add(recruiter);
            await _context.SaveChangesAsync(cancellationToken);

            return recruiter;
        }
    }
}
