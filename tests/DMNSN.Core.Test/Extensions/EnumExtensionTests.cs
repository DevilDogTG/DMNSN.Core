using System.ComponentModel;
using DMNSN.Core.Constraints;
using DMNSN.Core.Extensions;

namespace DMNSN.Core.Test.Extensions;

public class EnumExtensionTests
{
    private enum TestEnum
    {
        [Description("Test Description")]
        WithDescription,
        WithoutDescription
    }

    [Fact]
    public void Description_WithDescriptionAttribute_ReturnsDescription()
    {
        // Arrange
        var value = TestEnum.WithDescription;

        // Act
        var result = value.Description();

        // Assert
        Assert.Equal("Test Description", result);
    }

    [Fact]
    public void Description_WithoutDescriptionAttribute_ReturnsNull()
    {
        // Arrange
        var value = TestEnum.WithoutDescription;

        // Act
        var result = value.Description();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Description_WithFormatDateEnum_ReturnsCorrectDescription()
    {
        // Arrange
        var value = FormatDate._ddMMyyyy;

        // Act
        var result = value.Description();

        // Assert
        Assert.Equal("ddMMyyyy", result);
    }

    [Fact]
    public void GetAttribute_WithAttribute_ReturnsAttribute()
    {
        // Arrange
        var value = TestEnum.WithDescription;

        // Act
        var result = value.GetAttribute<DescriptionAttribute>();

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test Description", result?.Description);
    }

    [Fact]
    public void GetAttribute_WithoutAttribute_ReturnsNull()
    {
        // Arrange
        var value = TestEnum.WithoutDescription;

        // Act
        var result = value.GetAttribute<DescriptionAttribute>();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ToInt_WithValidEnum_ReturnsIntegerValue()
    {
        // Arrange
        var value = TestEnum.WithDescription; // 0

        // Act
        var result = value.ToInt();

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void ToInt_WithNonEnumType_ThrowsArgumentException()
    {
        // Arrange
        var value = 123;

        // Act & Assert
        var exception = Assert.Throws<ArgumentException>(() => value.ToInt());
        Assert.Equal("T must be an enumerated type", exception.Message);
    }
}
