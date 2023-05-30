using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.Vacancies.Models;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Vacancies.Queries.GetVacanciesByRecruiterGID
{
    public class GetVacanciesByRecruiterGIDHandler : IRequestHandler<GetVacanciesByRecruiterGIDRequest, GetItemsList<VacancyResponseModel>>
    {
        private readonly CoursworkContext _context;

        public GetVacanciesByRecruiterGIDHandler(CoursworkContext context)
        {
            _context = context;
        }

        public async ValueTask<GetItemsList<VacancyResponseModel>> Handle(GetVacanciesByRecruiterGIDRequest request, CancellationToken cancellationToken)
        {
            var vacancies = await (
                    from vacancy in _context.Vacancies
                    join vacancyStatus in _context.VacancyStatuses on vacancy.VacancyStatusGID equals vacancyStatus.GID
                    join recruiter in _context.Recruiters on vacancy.RecruiterGID equals recruiter.GID
                    join vacancySkills in _context.VacancySkills on vacancy.GID equals vacancySkills.VacancyGID
                    join skill in _context.Skills on vacancySkills.SkillGID equals skill.GID
                    group skill by vacancy into g
                    select new VacancyResponseModel
                    {
                        GID = g.Key.GID,
                        Name = g.Key.Name,
                        Description = g.Key.Description,
                        Salary = g.Key.Salary,
                        Location = g.Key.Location,
                        VacancyStatusName = g.Key.VacancyStatus.Name,
                        RecruiterFirstName = g.Key.Recruiter.FirstName,
                        RecruiterLastName = g.Key.Recruiter.LastName,
                        RecruiterPhoneNumber = g.Key.Recruiter.PhoneNumber,
                        Skills = g.ToList()
                    }
                ).ToListAsync(cancellationToken);



            return new GetItemsList<VacancyResponseModel> { Items = vacancies };
        }
    }
}
