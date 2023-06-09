using Coursework.Domain.Entities;
using Coursework.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.Tests.Helpers
{
    public class BaseTest : IDisposable
    {
        protected readonly CoursworkContext _dbContext;

        public BaseTest()
        {
            _dbContext = InitTestDbContext();
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        public CoursworkContext InitTestDbContext()
        {
            var options = new DbContextOptionsBuilder<CoursworkContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new CoursworkContext(options);
            context.Database.EnsureCreated();

            SeedDb(context);
            context.SaveChanges();

            return context;
        }

        private void SeedDb(CoursworkContext context)
        {
            if (!context.Skills.Any())
            {
                var skill = new List<Skill>()
                {
                    new Skill
                    {
                        GID = Guid.Parse("90549a97-df2a-456b-8dc9-14382ed52cef"),
                        Name = "TestName"
                    },
                    new Skill
                    {
                        GID = Guid.Parse("8c4648e8-67f2-4276-a240-00b98467e565"),
                        Name = "TestName"
                    }
                };

                context.AddRange(skill);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new List<User>()
                {
                    new User
                    {
                        GID = Guid.Parse("90549a97-df2a-456b-8dc9-14382ed52cef"),
                        Email = "TestEmail",
                        Password = "TestPassword",
                        Role = "TestRole"
                    },
                    new User
                    {
                        GID = Guid.Parse("8c4648e8-67f2-4276-a240-00b98467e565"),
                        Email = "TestEmail",
                        Password = "TestPassword",
                        Role = "TestRole"
                    }
                };

                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
