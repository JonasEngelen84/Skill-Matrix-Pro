using System.ComponentModel.DataAnnotations;

namespace SkillMatrixPro.Domain.Entities
{
    public class Project
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(5000)]
        public string? Description { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }

        public ICollection<EmployeeProject> Members { get; private set; } = [];

        private Project() { }

        public static Project Create(string name, DateTime startDate, DateTime? endDate, string? description)
        {
            ValidateProjectData(name, startDate, endDate);

            return new Project
            {
                Id = Guid.NewGuid(),
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Description = description
            };
        }

        public void Update(string name, DateTime startDate, DateTime? endDate, string? description)
        {
            ValidateProjectData(name, startDate, endDate);

            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        private static void ValidateProjectData(string name, DateTime startDate, DateTime? endDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            if (endDate.HasValue && endDate < startDate)
                throw new ArgumentException("End date must be after start date.", nameof(endDate));
        }
    }
}
