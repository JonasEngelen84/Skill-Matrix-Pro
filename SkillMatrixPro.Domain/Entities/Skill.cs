using System.ComponentModel.DataAnnotations;

namespace SkillMatrixPro.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(1000)]
        public string Description { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public SkillCategory Category { get; set; } = null!;

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; } = [];
    }
}
