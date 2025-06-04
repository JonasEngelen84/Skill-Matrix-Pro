using SkillMatrixPro.Domain.Enums;

namespace SkillMatrixPro.Domain.Entities
{
    public class EmployeeProject
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public EmployeeRole Role { get; set; }

        public DateTime AssignedOn { get; set; } = DateTime.UtcNow;
    }
}
