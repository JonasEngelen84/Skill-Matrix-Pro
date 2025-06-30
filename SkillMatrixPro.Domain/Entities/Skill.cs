using System.ComponentModel.DataAnnotations;

namespace SkillMatrixPro.Domain.Entities
{
    public class Skill
    {
        public Guid Id { get; private set; }

        [MaxLength(100)]
        public string Name { get; private set; } = null!;

        [MaxLength(5000)]
        public string? Description { get; private set; }

        public Guid CategoryId { get; private set; }
        public SkillCategory Category { get; private set; } = null!;

        public ICollection<EmployeeSkill> Employees { get; private set; } = [];

        private Skill() { }

        public static Skill Create(string name, SkillCategory category, string? description)
        {
            ValidateSkillData(name);

            return new Skill
            {
                Id = Guid.NewGuid(),
                Name = name,
                Category = category,
                CategoryId = category.Id,
                Description = description
            };
        }

        public void Update(string name, SkillCategory category, string? description)
        {
            ValidateSkillData(name);

            Name = name;
            Category = category;
            CategoryId = category.Id;
            Description = description;
        }

        private static void ValidateSkillData(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Skill name is required.", nameof(name));
        }

        public void UpdateEmployeesList(EmployeeSkill employee)
        {
            if (!Employees.Contains(employee))
                Employees.Add(employee);
            else
            {
                EmployeeSkill employeeSkill = Employees.First(es => es.EmployeeId == employee.EmployeeId);
                Employees.Remove(employeeSkill);
            }
        }

        public override bool Equals(object? obj) => obj is Skill other && Id == other.Id;

        public override int GetHashCode() => Id.GetHashCode();
    }
}
