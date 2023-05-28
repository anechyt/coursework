using Coursework.Application.Infrastructure.Mapper;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;

namespace Coursework.Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateHandler : ICommandHandler<CreateCandidateRequest, Candidate?>
    {
        private readonly CoursworkContext _context;

        public CreateCandidateHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<Candidate?> Handle(CreateCandidateRequest command, CancellationToken cancellationToken)
        {
            var mapper = new CourseworkMapper();

            var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var candidate = mapper.CreateCandidateCommandMapper(command);
                var skills = mapper.SkillModelMapper(command.Skills);

                _context.Skills.AddRange(skills);
                _context.Candidates.Add(candidate);

                foreach (var skill in skills)
                {
                    var candidateSkill = new CandidateSkill
                    {
                        CandidateGID = candidate.GID,
                        SkillGID = skill.GID,
                        Skill = skill,
                        Candidate = candidate
                    };

                    _context.CandidateSkills.Add(candidateSkill);
                }
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return candidate;
            }
            catch (Exception ex) 
            {
                await transaction.RollbackAsync(cancellationToken);
                throw ex;
            }
        }
    }
}
