using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.VacancyStatuses.Commands.CreateVacancyStatus;
using Coursework.Application.VacancyStatuses.Commands.DeleteVacancyStatus;
using Coursework.Application.VacancyStatuses.Commands.UpdateVacancyStatus;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Сoursework.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyStatusesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CoursworkContext _context;

        public VacancyStatusesController(IMediator mediator, CoursworkContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVacancyStatus([FromBody] CreateVacancyStatusRequest createVacancyStatusRequest)
        {
            var result = await _mediator.Send(createVacancyStatusRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVacancyStatus([FromBody] DeleteVacancyStatusRequest deleteVacancyStatusRequest)
        {
            var result = await _mediator.Send(deleteVacancyStatusRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVacancyStatus([FromBody] UpdateVacancyStatusRequest updateVacancyStatusRequest)
        {
            var result = await _mediator.Send(updateVacancyStatusRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancyStatuses(CancellationToken cancellationToken)
        {
            var vacancyStatuses = await _context.VacancyStatuses.AsNoTracking().ToListAsync(cancellationToken);

            return Ok(new GetItemsList<VacancyStatus> { Items = vacancyStatuses });
        }
    }
}
