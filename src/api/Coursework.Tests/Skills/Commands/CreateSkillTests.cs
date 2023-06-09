using Coursework.Application.Models;
using Coursework.Application.Skills.Commands.CreateSkill;
using Coursework.Tests.Helpers;
using System.Threading.Tasks;
using System.Threading;

namespace Coursework.Tests.Skills.Commands
{
    public abstract class CreateSkillTests
    {
        public abstract class CreateSkillRequestTest : BaseTest
        {
            protected readonly CreateSkillRequest _skillRequest;

            protected readonly CreateSkillHandler _skillHandler;

            protected CreateSkillRequestTest()
            {
                _skillRequest = new CreateSkillRequest()
                {
                    Name = "TestName"
                };

                _skillHandler = new CreateSkillHandler(_dbContext);
            }
        }

        public class Handler : CreateSkillRequestTest
        {
            [Fact]
            public async Task Skill_model_is_returned_when_request_is_valid()
            {
                var expectedSkill = new SkillModel
                {
                    Name = "TestName"
                };
                var result = await _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Should().BeEquivalentTo(expectedSkill);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _skillRequest.Name = string.Empty;

                var result = await _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Should().NotBeNull();
            }
        }
    }
}
