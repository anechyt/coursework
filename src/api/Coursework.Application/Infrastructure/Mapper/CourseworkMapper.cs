using Coursework.Application.Candidates.Commands.CreateCandidate;
using Coursework.Application.Candidates.Commands.UpdateCandidate;
using Coursework.Application.Recruiters.Commands.CreateRecruiter;
using Coursework.Application.Recruiters.Commands.UpdateRecruiter;
using Coursework.Application.Skills.Commands.CreateSkill;
using Coursework.Application.VacancyStatuses.Commands.CreateVacancyStatus;
using Coursework.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Coursework.Application.Infrastructure.Mapper
{
    [Mapper]
    public partial class CourseworkMapper
    {
        public partial Skill CreateSkillCommandMapper(CreateSkillRequest skillRequest);

        public partial VacancyStatus CreateVacancyStatusCommandMapper(CreateVacancyStatusRequest vacancyStatusRequest);

        public partial Candidate CreateCandidateCommandMapper(CreateCandidateRequest candidateRequest);
        public partial Candidate UpdateCandidateCommandMapper(UpdateCandidateRequest candidateRequest);

        public partial Recruiter CreateRecruiterCommandMapper(CreateRecruiterRequest createRecruiterRequest);
        public partial Recruiter UpdateRecruiterCommandMapper(UpdateRecruiterRequest updateRecruiterRequest);
    }
}
