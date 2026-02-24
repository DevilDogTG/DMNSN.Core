using DMNSN.Core.Extensions;

namespace DMNSN.Core.Test.Extensions;

/// <summary>
/// Unit tests for ConvertExtension boolean-related methods.
/// </summary>
public class ConvertExtensionBooleanTests
{
    #region ParseBoolean Tests

    /// <summary>
    /// Tests that ParseBoolean returns false for a null string.
    /// </summary>
    [Fact]
    public void ParseBoolean_WithNullString_ReturnsFalse()
    {
        // Arrange
        string? nullString = null;

        // Act
        var result = nullString.ParseBoolean();

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns false for an empty string.
    /// </summary>
    [Fact]
    public void ParseBoolean_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        const string emptyString = "";

        // Act
        var result = emptyString.ParseBoolean();

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns false for a string containing only whitespace.
    /// </summary>
    [Fact]
    public void ParseBoolean_WithWhitespaceOnly_ReturnsFalse()
    {
        // Arrange
        const string whitespaceString = "   ";

        // Act
        var result = whitespaceString.ParseBoolean();

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns true for variations of "true".
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("true")]
    [InlineData("TRUE")]
    [InlineData("True")]
    [InlineData("TrUe")]
    public void ParseBoolean_WithTrueVariations_ReturnsTrue(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns true for variations of "yes".
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("yes")]
    [InlineData("YES")]
    [InlineData("Yes")]
    [InlineData("YeS")]
    public void ParseBoolean_WithYesVariations_ReturnsTrue(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns true for variations of "y".
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("y")]
    [InlineData("Y")]
    public void ParseBoolean_WithYVariations_ReturnsTrue(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns true for "1".
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("1")]
    public void ParseBoolean_WithOne_ReturnsTrue(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns false for various false-like values.
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("false")]
    [InlineData("no")]
    [InlineData("n")]
    [InlineData("0")]
    [InlineData("2")]
    [InlineData("anything")]
    [InlineData("random")]
    [InlineData("maybe")]
    public void ParseBoolean_WithFalseValues_ReturnsFalse(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns true for true-like values containing whitespace.
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("  true  ")]
    [InlineData("  yes  ")]
    [InlineData("  y  ")]
    [InlineData("  1  ")]
    public void ParseBoolean_WithTrueValuesAndWhitespace_ReturnsTrue(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns false for false-like values containing whitespace.
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("  false  ")]
    [InlineData("  no  ")]
    [InlineData("  0  ")]
    [InlineData("  random  ")]
    public void ParseBoolean_WithFalseValuesAndWhitespace_ReturnsFalse(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.False(result);
    }

    /// <summary>
    /// Tests that ParseBoolean returns true for true-like values containing various whitespace characters.
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("\ttrue\t")]
    [InlineData("\nyes\n")]
    [InlineData("\r\ny\r\n")]
    public void ParseBoolean_WithTrueValuesAndVariousWhitespace_ReturnsTrue(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.True(result);
    }

    /// <summary>
    /// Tests that ParseBoolean functionality is case-insensitive.
    /// </summary>
    [Fact]
    public void ParseBoolean_CaseInsensitiveComparison_WorksCorrectly()
    {
        // Arrange & Act & Assert
        Assert.True("TRUE".ParseBoolean());
        Assert.True("true".ParseBoolean());
        Assert.True("True".ParseBoolean());
        Assert.True("tRuE".ParseBoolean());

        Assert.True("YES".ParseBoolean());
        Assert.True("yes".ParseBoolean());
        Assert.True("Yes".ParseBoolean());
        Assert.True("yEs".ParseBoolean());

        Assert.True("Y".ParseBoolean());
        Assert.True("y".ParseBoolean());
    }

    /// <summary>
    /// Tests that ParseBoolean returns false for various empty or whitespace inputs.
    /// </summary>
    /// <param name="input">The input string.</param>
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData("\r\n")]
    [InlineData("   \t\n   ")]
    public void ParseBoolean_WithVariousEmptyOrWhitespaceInputs_ReturnsFalse(string input)
    {
        // Act
        var result = input.ParseBoolean();

        // Assert
        Assert.False(result);
    }

    #endregion

    #region Integration Tests with String Methods

    /// <summary>
    /// Tests that ParseBoolean works correctly when chained with ParseString.
    /// </summary>
    [Fact]
    public void ParseBoolean_AfterParseString_WorksCorrectly()
    {
        // Arrange
        const bool boolValue = true;

        // Act
        var stringResult = boolValue.ParseString();
        var boolResult = stringResult.ParseBoolean();

        // Assert
        Assert.True(boolResult);
    }

    /// <summary>
    /// Tests that ParseBoolean works correctly when chained with TrimLength.
    /// </summary>
    [Fact]
    public void ParseBoolean_AfterTrimLength_WorksCorrectly()
    {
        // Arrange
        const string input = "true123";
        const int maxLength = 4;

        // Act
        var trimmedResult = input.TrimLength(maxLength);
        var boolResult = trimmedResult.ParseBoolean();

        // Assert
        Assert.True(boolResult);
    }

    /// <summary>
    /// Tests that ParseBoolean works correctly when chained with ReverseSubstring.
    /// </summary>
    [Fact]
    public void ParseBoolean_AfterReverseSubstring_WorksCorrectly()
    {
        // Arrange
        const string input = "falseyes";
        const int count = 3;

        // Act
        var substringResult = input.ReverseSubstring(count);
        var boolResult = substringResult.ParseBoolean();

        // Assert
        Assert.True(boolResult);
    }

    #endregion
}