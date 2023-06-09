using Coursework.Application.Vacancies.Models;
using Coursework.Infrastructure.PartialSearch.Abstract;
using Coursework.Infrastructure.PartialSearch.Models;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Vacancies.Queries.GetVacanciesBySkills
{
    public class GetVacanciesBySkillsHandler : IRequestHandler<GetVacanciesBySkillsRequest, List<VacancyWithScoreResponseModel>>
    {
        private readonly CoursworkContext _context;
        private readonly IPartialSearchService _partialSearchService;

        public GetVacanciesBySkillsHandler(CoursworkContext context, IPartialSearchService partialSearchService)
        {
            _context = context;
            _partialSearchService = partialSearchService;
        }

        public async ValueTask<List<VacancyWithScoreResponseModel>> Handle(GetVacanciesBySkillsRequest request, CancellationToken cancellationToken)
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

            var searchedResult = new List<VacancyWithScoreResponseModel>();

            foreach (var vacancy in vacancies)
            {
                var searchModel = new PartialSearchModel
                {
                    SearchList = new List<string>(vacancy.Skills.Select(s => s.Name)),
                    Requests = new List<string>(request.Skills)
                };

                var searchScoreResult = _partialSearchService.PartialSearch(searchModel);

                var searchedCandidate = new VacancyWithScoreResponseModel
                {
                    GID = vacancy.GID,
                    Name = vacancy.Name,
                    Description = vacancy.Description,
                    Salary = vacancy.Salary,
                    Location = vacancy.Location,
                    VacancyStatusName = vacancy.VacancyStatusName,
                    RecruiterFirstName = vacancy.RecruiterFirstName,
                    RecruiterLastName = vacancy.RecruiterLastName,
                    RecruiterPhoneNumber = vacancy.RecruiterPhoneNumber,
                    Skills = vacancy.Skills,
                    Score = searchScoreResult
                };

                searchedResult.Add(searchedCandidate);
            }

            return searchedResult.OrderByDescending(c => c.Score).ToList();
        }
    }
}
