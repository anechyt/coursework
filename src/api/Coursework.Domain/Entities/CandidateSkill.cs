namespace Coursework.Domain.Entities
{
    public class CandidateSkill
    {
        public Guid CandidateGID { get; set; }

        public Guid SkillGID { get; set; }

        public Skill Skill { get; set; }

        public Candidate Candidate { get; set; }
    }
}
