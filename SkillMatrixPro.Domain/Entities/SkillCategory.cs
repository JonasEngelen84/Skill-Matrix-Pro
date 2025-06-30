using System.ComponentModel.DataAnnotations;

namespace SkillMatrixPro.Domain.Entities
{
    public class SkillCategory
    {
        public Guid Id { get; private set; }

        [MaxLength(200)]
        public string Name { get; set; } = null!;

        public ICollection<Skill> Skills { get; set; } = [];

        private SkillCategory() { }

        public SkillCategory(string name)
        {
            Id = new Guid();
            Name = name;
        }
    }
}
