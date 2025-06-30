using System.ComponentModel.DataAnnotations;

namespace SkillMatrixPro.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }

        [MaxLength(50)]
        public string FirstName { get; private set; } = null!;

        [MaxLength(50)]
        public string LastName { get; private set; } = null!;

        [MaxLength(100)]
        public string Email { get; private set; } = null!;

        public ICollection<EmployeeSkill> Skills { get; private set; } = [];
        public ICollection<EmployeeSkillTarget> SkillTargets { get; private set; } = [];

        private Employee() { }

        public static Employee Create(string firstName, string lastName, string email,
            ICollection<EmployeeSkill> employeeSkills, ICollection<EmployeeSkillTarget> skillTargets)
        {
            ValidateEmployeeData(firstName, lastName, email);

            return new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Skills = employeeSkills,
                SkillTargets = skillTargets
            };
        }

        public void Update(string firstName, string lastName, string email,
            ICollection<EmployeeSkill> employeeSkills, ICollection<EmployeeSkillTarget> skillTargets)
        {
            ValidateEmployeeData(firstName, lastName, email);

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Skills = employeeSkills;
            SkillTargets = skillTargets;
        }

        private static void ValidateEmployeeData(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Firstname is required.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Lastname is required.", nameof(lastName));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.", nameof(email));

            if (!new EmailAddressAttribute().IsValid(email))
                throw new ArgumentException("Invalid email format.", nameof(email));
        }

        public override bool Equals(object? obj) => obj is Employee other && Id == other.Id;
        public override int GetHashCode() => Id.GetHashCode();
    }
}