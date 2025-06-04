using SkillMatrixPro.Domain.Value_Objects;

namespace SkillMatrixPro.Domain.Entities
{
    public class EmployeeSkill
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = null!;

        public SkillLevel Level { get; set; } = null!;
        public string? Comment { get; set; }
    }
}
