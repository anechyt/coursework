using Coursework.Domain.Entities;
using Mediator;

namespace Coursework.Application.Recruiters.Commands.CreateRecruiter
{
    public class CreateRecruiterRequest : ICommand<Recruiter>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string CompanyName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Biography { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string UserGID { get; set; }
    }
}
