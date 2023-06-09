using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.Vacancies.Models;
using Mediator;

namespace Coursework.Application.Vacancies.Queries.GetVacanciesNearbyCandidate
{
    public class GetVacanciesNearbyCandidateRequest : IRequest<GetItemsList<VacancyResponseModel>>
    {
        public Guid UserGID { get; set; }

        public int MaxDistance { get; set; }
    }
}
