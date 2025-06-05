namespace SkillMatrixPro.Domain.Entities
{
    public class EmployeeSkillTarget
    {
        public Guid Id { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = null!;

        public int TargetLevel { get; set; }
        public DateTime TargetDate { get; set; }
    }
}
