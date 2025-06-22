using SkillMatrixPro.Domain.Entities;
using SkillMatrixPro.Domain.Value_Objects;

namespace SkillMatrixPro.Tests
{
    public class EmployeeSkillTargetTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(6)]
        public void Constructor_InvalidTargetLevel_ThrowsArgumentOutOfRangeException(SkillLevel invalidLevel)
        {
            var employee = Guid.NewGuid();
            var skill = Guid.NewGuid();
            var futureDate = DateTime.UtcNow.AddDays(1);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new EmployeeSkillTarget(employee, skill, invalidLevel, futureDate));
        }

        [Fact]
        public void Constructor_TargetDateInPast_ThrowsArgumentException()
        {
            var employee = Guid.NewGuid();
            var skill = Guid.NewGuid();
            var pastDate = DateTime.UtcNow.AddDays(-1);

            Assert.Throws<ArgumentException>(() =>
                new EmployeeSkillTarget(employee, skill, 3, pastDate));
        }

        [Fact]
        public void Constructor_ValidParameters_CreatesObjectCorrectly()
        {
            var employee = Guid.NewGuid();
            var skill = Guid.NewGuid();
            var targetLevel = 4;
            var targetDate = DateTime.UtcNow.AddDays(10);

            var target = new EmployeeSkillTarget(employee, skill, targetLevel, targetDate);

            Assert.Equal(employee, target.EmployeeId);
            Assert.Equal(skill, target.SkillId);
            Assert.Equal(targetLevel, target.TargetLevel);
            Assert.Equal(targetDate.Date, target.TargetDate);
        }
    }
}
