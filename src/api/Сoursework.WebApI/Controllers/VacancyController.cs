using Coursework.Application.Vacancies.Commands.CreateVacancy;
using Coursework.Application.Vacancies.Commands.DeleteVacancy;
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

        [HttpPost]
        public async Task<IActionResult> CreateVacancy([FromBody] CreateVacancyRequest createVacancyRequest)
        {
            var result = await _mediator.Send(createVacancyRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVacancy([FromBody] DeleteVacancyRequest deleteVacancyRequest)
        {
            var result = await _mediator.Send(deleteVacancyRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancies(CancellationToken cancellationToken)
        {
            var vacancies = await _context.Vacancies.AsNoTracking().ToListAsync(cancellationToken);

            return Ok(vacancies);
        }
    }
}
