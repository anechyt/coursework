using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Recruiters.Commands.UpdateRecruiter
{
    public class UpdateRecruiterRequest : ICommand<Recruiter>
    {
        public Guid GID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Biography { get; set; } = null!;

        public string Location { get; set; } = null!;

        public Guid UserGID { get; set; }

    }
}
