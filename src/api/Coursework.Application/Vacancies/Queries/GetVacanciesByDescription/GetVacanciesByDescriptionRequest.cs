using Coursework.Application.Vacancies.Models;
using Mediator;

namespace Coursework.Application.Vacancies.Queries.GetVacanciesByDescription
{
    public class GetVacanciesByDescriptionRequest : IRequest<List<VacancyWithScoreResponseModel>>
    {
        public List<string> Description { get; set; }
    }
}
