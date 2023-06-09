using Coursework.Application.Vacancies.Models;
using Mediator;

namespace Coursework.Application.Vacancies.Queries.GetVacanciesBySkills
{
    public class GetVacanciesBySkillsRequest : IRequest<List<VacancyWithScoreResponseModel>>
    {
        public List<string> Skills { get; set; }
    }
}
