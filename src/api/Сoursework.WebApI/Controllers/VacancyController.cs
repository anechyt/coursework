using Coursework.Application.Recruiters.Queries.GetRecruiterByUserGID;
using Coursework.Application.Vacancies.Commands.CreateVacancy;
using Coursework.Application.Vacancies.Commands.DeleteVacancy;
using Coursework.Application.Vacancies.Queries.GetVacanciesByRecruiterGID;
using Coursework.Persistence;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Сoursework.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CoursworkContext _context;

        public VacancyController(IMediator mediator, CoursworkContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateVacancy([FromBody] CreateVacancyRequest createVacancyRequest)
        {
            var result = await _mediator.Send(createVacancyRequest);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteVacancy([FromBody] DeleteVacancyRequest deleteVacancyRequest)
        {
            var result = await _mediator.Send(deleteVacancyRequest);
            return Ok(result);
        }

        [HttpGet("vacancies")]
        public async Task<IActionResult> GetAllVacancies(CancellationToken cancellationToken)
        {
            var vacancies = await _context.Vacancies.AsNoTracking().ToListAsync(cancellationToken);

            return Ok(vacancies);
        }

        [HttpGet("vacanciesbyrecruitergid")]
        public async Task<IActionResult> GetVacanciesByRecruiterGID(string recruiterGID)
        {
            var result = await _mediator.Send(new GetVacanciesByRecruiterGIDRequest { RecruiterGID = Guid.Parse(recruiterGID) });

            return Ok(result);
        }
    }
}
