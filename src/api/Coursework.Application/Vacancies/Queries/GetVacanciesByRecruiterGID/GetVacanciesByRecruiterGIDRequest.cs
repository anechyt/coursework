using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.Vacancies.Models;
using Mediator;

namespace Coursework.Application.Vacancies.Queries.GetVacanciesByRecruiterGID
{
    public class GetVacanciesByRecruiterGIDRequest : IRequest<GetItemsList<VacancyResponseModel>>
    {
        public Guid RecruiterGID { get; set; }
    }
}
