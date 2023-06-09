using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.NearbySearch.Abstract;
using Coursework.Application.NearbySearch.Models;
using Coursework.Application.Vacancies.Models;
using Coursework.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Coursework.Application.Vacancies.Queries.GetVacanciesNearbyCandidate
{
    public class GetVacanciesNearbyCandidateHandler : IRequestHandler<GetVacanciesNearbyCandidateRequest, GetItemsList<VacancyResponseModel>>
    {
        private readonly CoursworkContext _context;
        private readonly INearbySearchService _nearbySearchService;

        public GetVacanciesNearbyCandidateHandler(CoursworkContext context, INearbySearchService nearbySearchService)
        {
            _context = context;
            _nearbySearchService = nearbySearchService;
        }

        public async ValueTask<GetItemsList<VacancyResponseModel>> Handle(GetVacanciesNearbyCandidateRequest request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.AsNoTracking().FirstOrDefaultAsync(e => e.UserGID == request.UserGID);
            var result = new GetItemsList<VacancyResponseModel>();

            if (candidate is null)
                throw new Exception($"Candidate with Guid {request.UserGID} not found");

            var candidateLocation = await _nearbySearchService.GetLocationByAddress(candidate.Location, cancellationToken);

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

            foreach (var vacancy in vacancies)
            {
                var isMatch = await _nearbySearchService.CheckCityInRadius(new LocationRequestModel
                {
                    MainLocation = candidateLocation,
                    ReferenceAddress = vacancy.Location,
                    MaxDistance = request.MaxDistance
                }, cancellationToken);

                if (isMatch)
                {
                    result.Items.Add(vacancy);
                }
            }

            return result;
        }
    }
}
