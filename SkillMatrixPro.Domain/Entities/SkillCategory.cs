using System.ComponentModel.DataAnnotations;

namespace SkillMatrixPro.Domain.Entities
{
    public class SkillCategory
    {
        public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        public ICollection<Skill> Skills { get; set; } = [];
    }
}
