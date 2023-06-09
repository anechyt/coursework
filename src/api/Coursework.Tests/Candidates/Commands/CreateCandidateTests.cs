using Azure;
using Coursework.Application.Candidates.Commands.CreateCandidate;
using Coursework.Tests.Helpers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
using Coursework.Domain.Entities;
using System.Collections.Generic;
using Coursework.Application.Models;

namespace Coursework.Tests.Candidates.Commands
{
    public abstract class CreateCandidateTest : BaseTest
    {
        protected readonly CreateCandidateRequest _candidateRequest;

        protected readonly CreateCandidateHandler _candidateHandler;

        protected CreateCandidateTest()
        {
            var skills = new List<SkillModel>()
                {
                    new SkillModel
                    {
                        Name = "TestName"
                    },
                    new SkillModel
                    {
                        Name = "Test"
                    }
                };

            _candidateRequest = new CreateCandidateRequest()
            {
                FirstName = "TestName",
                LastName = "TestName",
                PhoneNumber = "TestPhone",
                Biography = "TestBiography",
                Resume = "TestResume",
                Location = "TestLocation",
                Skills = skills,
                UserGID = "8c4648e8-67f2-4276-a240-00b98467e565",
            };

            _candidateHandler = new CreateCandidateHandler(_dbContext);
        }
    }

    public class Handle : CreateCandidateTest
    {
        [Fact]
        public async Task Bad_request_is_returned_when_request_is_invalid()
        {
            _candidateRequest.FirstName = null;

            var result = _candidateHandler.Handle(_candidateRequest, new CancellationToken());

            result.Should().NotBeNull();
        }
    }
}
