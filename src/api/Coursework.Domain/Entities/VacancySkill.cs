namespace Coursework.Domain.Entities
{
    public class VacancySkill
    {
        public Guid VacancyGID { get; set; }

        public Guid SkillGID { get; set; }

        public Skill Skill { get; set; }

        public Vacancy Vacancy { get; set; }
    }
}
