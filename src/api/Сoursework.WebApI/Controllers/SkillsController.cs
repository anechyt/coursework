using Coursework.Application.Models.GetAllQuery;
using Coursework.Application.Skills.Commands.CreateSkill;
using Coursework.Application.Skills.Commands.DeleteSkill;
using Coursework.Application.Skills.Commands.UpdateSkill;
using Coursework.Domain.Entities;
using Coursework.Persistence;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Сoursework.WebApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CoursworkContext _context;

        public SkillsController(IMediator mediator, CoursworkContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] CreateSkillRequest createSkillRequest)
        {
            var result = await _mediator.Send(createSkillRequest);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSkill([FromBody] DeleteSkillRequest deleteSkillRequest)
        {
            var result = await _mediator.Send(deleteSkillRequest);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSkill([FromBody] UpdateSkillRequest updateSkillRequest)
        {
            var result = await _mediator.Send(updateSkillRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills(CancellationToken cancellationToken)
        {
            var skills = await _context.Skills.AsNoTracking().ToListAsync(cancellationToken);

            return Ok(new GetItemsList<Skill> { Items = skills });
        }
    }
}
