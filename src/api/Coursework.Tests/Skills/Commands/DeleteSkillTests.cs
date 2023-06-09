using Coursework.Application.Skills.Commands.DeleteSkill;
using Coursework.Tests.Helpers;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Coursework.Tests.Skills.Commands
{
    public abstract class DeleteSkillTests
    {
        public abstract class DeleteSkillTest : BaseTest
        {
            protected readonly DeleteSkillRequest _skillRequest;

            protected readonly DeleteSkillHandler _skillHandler;

            protected DeleteSkillTest()
            {
                _skillRequest = new DeleteSkillRequest()
                {
                    GID = Guid.Parse("90549a97-df2a-456b-8dc9-14382ed52cef"),
                };

                _skillHandler = new DeleteSkillHandler(_dbContext);
            }
        }

        public class Handle : DeleteSkillTest
        {
            [Fact]
            public async Task Deleted_Id_is_returned_when_request_is_valid()
            {
                var expectedId = Guid.Parse("90549a97-df2a-456b-8dc9-14382ed52cef");

                var result = await _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Should().Be(expectedId);
            }

            [Fact]
            public async Task Bad_request_is_returned_when_request_is_invalid()
            {
                _skillRequest.GID = Guid.Parse("90549a97-df2a-456b-8dc9-14382ed52ced");

                var result = _skillHandler.Handle(_skillRequest, new CancellationToken());

                result.Should().NotBeNull();
            }
        }
    }
}
