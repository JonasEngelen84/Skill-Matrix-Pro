using SkillMatrixPro.Domain.Value_Objects;

namespace SkillMatrixPro.Domain.Entities
{
    public class EmployeeSkill
    {
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public Guid SkillId { get; private set; }
        public Skill Skill { get; private set; } = null!;

        public SkillLevel Level { get; set; } = null!;
        public string? Comment { get; set; }

        private EmployeeSkill() { }

        public EmployeeSkill(Employee employee, Skill skill, SkillLevel level)
        {
            if (level < 1 || level > 5)
                throw new ArgumentOutOfRangeException(nameof(level), "Skill level must be between 1 and 5.");

            Employee = employee;
            EmployeeId = employee.Id;
            Skill = skill;
            SkillId = skill.Id;
            Level = level;
        }
    }
}
