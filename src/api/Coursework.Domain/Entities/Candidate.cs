namespace Coursework.Domain.Entities
{
    public class Candidate
    {
        public Guid GID { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Biography { get; set; } = null!;

        public string Resume { get; set; } = null!;

        public string Location { get; set; }

        public Guid UserGID { get; set; }

        public virtual User User { get; set; }
    }
}
