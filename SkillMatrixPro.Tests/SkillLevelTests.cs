using SkillMatrixPro.Domain.Value_Objects;

namespace SkillMatrixPro.Tests;

public class SkillLevelTests
{
    [Fact]
    public void Constructor_ValidValue_SetsValue()
    {
        var level = new SkillLevel(3);
        Assert.Equal(3, level.Value);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(6)]
    public void Constructor_InvalidValue_ThrowsException(int invalidValue)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SkillLevel(invalidValue));
    }
}
