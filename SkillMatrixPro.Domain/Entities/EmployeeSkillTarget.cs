using SkillMatrixPro.Domain.Value_Objects;

namespace SkillMatrixPro.Domain.Entities
{
    public class EmployeeSkillTarget
    {
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public Guid SkillId { get; private set; }
        public Skill Skill { get; private set; } = null!;

        public SkillLevel TargetLevel { get; set; } = null!;
        public DateTime TargetDate { get; set; }

        public string? Comment { get; set; }

        private EmployeeSkillTarget() { }

        public EmployeeSkillTarget(Employee employee, Skill skill, SkillLevel targetLevel, DateTime targetDate)
        {
            if (targetLevel < 1 || targetLevel > 5)
                throw new ArgumentOutOfRangeException(nameof(targetLevel), "Target level must be between 1 and 5.");

            if (targetDate.Date < DateTime.UtcNow.Date)
                throw new ArgumentException("Target date must not be in past.", nameof(targetDate));

            Employee = employee;
            EmployeeId = employee.Id;
            Skill = skill;
            SkillId = skill.Id;
            TargetLevel = targetLevel;
            TargetDate = targetDate.Date;
        }
    }
}
