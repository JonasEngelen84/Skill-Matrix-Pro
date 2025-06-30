using SkillMatrixPro.Domain.Enums;

namespace SkillMatrixPro.Domain.Entities
{
    public class EmployeeProject
    {
        public Guid EmployeeId { get; private set; }
        public Employee Employee { get; private set; } = null!;

        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; } = null!;

        public EmployeeRole Role { get; set; }

        public DateTime AssignedOn { get; set; } = DateTime.UtcNow;

        private EmployeeProject() { }

        public EmployeeProject(Employee employee, Project project, EmployeeRole role)
        {
            Employee = employee;
            EmployeeId = employee.Id;
            Project = project;
            ProjectId = project.Id;
            Role = role;
        }
    }
}
