using Coursework.Domain.Entities;

namespace Coursework.Application.Candidates.Models
{
    public class CandidateResponseModel
    {
        public Guid GID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Biography { get; set; } = null!;

        public string Resume { get; set; } = null!;

        public string Location { get; set; }

        public List<Skill> Skills { get; set; }

        public Guid UserGID { get; set; }
    }
}
