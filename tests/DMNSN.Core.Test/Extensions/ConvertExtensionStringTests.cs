using DMNSN.Core.Extensions;

namespace DMNSN.Core.Test.Extensions;

/// <summary>
/// Unit tests for ConvertExtension string-related methods.
/// </summary>
public class ConvertExtensionStringTests
{
    #region ParseString Tests

    [Fact]
    public void ParseString_WithNullObject_ReturnsDefaultValue()
    {
        // Arrange
        object? nullObject = null;
        const string expectedDefault = "";

        // Act
        var result = nullObject?.ParseString();

        // Assert
        Assert.Equal(expectedDefault, result);
    }

    [Fact]
    public void ParseString_WithNullObjectAndCustomDefault_ReturnsCustomDefault()
    {
        // Arrange
        object? nullObject = null;
        const string customDefault = "custom default";

        // Act
        var result = nullObject?.ParseString(customDefault);

        // Assert
        Assert.Equal(customDefault, result);
    }

    [Fact]
    public void ParseString_WithValidObject_ReturnsStringRepresentation()
    {
        // Arrange
        const int testObject = 42;
        const string expected = "42";

        // Act
        var result = testObject.ParseString();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseString_WithStringObject_ReturnsOriginalString()
    {
        // Arrange
        const string testString = "Hello World";

        // Act
        var result = testString.ParseString();

        // Assert
        Assert.Equal(testString, result);
    }

    [Fact]
    public void ParseString_WithBooleanTrue_ReturnsTrue()
    {
        // Arrange
        const bool testBool = true;
        const string expected = "True";

        // Act
        var result = testBool.ParseString();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ParseString_WithDateTime_ReturnsDateTimeString()
    {
        // Arrange
        var testDate = new DateTime(2024, 1, 1, 12, 0, 0);
        var expected = testDate.ToString();

        // Act
        var result = testDate.ParseString();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(123, "123")]
    [InlineData(123.45, "123.45")]
    [InlineData('A', "A")]
    [InlineData(true, "True")]
    [InlineData(false, "False")]
    public void ParseString_WithVariousTypes_ReturnsCorrectStringRepresentation(object input, string expected)
    {
        // Act
        var result = input.ParseString();

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region TrimLength Tests

    [Fact]
    public void TrimLength_WithNullString_ReturnsNull()
    {
        // Arrange
        string? nullString = null;

        // Act
        var result = nullString?.TrimLength(10);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TrimLength_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        const string emptyString = "";

        // Act
        var result = emptyString.TrimLength(10);

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void TrimLength_WithStringLengthEqualToMaxLength_ReturnsOriginalString()
    {
        // Arrange
        const string testString = "Hello";
        const int maxLength = 5;

        // Act
        var result = testString.TrimLength(maxLength);

        // Assert
        Assert.Equal(testString, result);
    }

    [Fact]
    public void TrimLength_WithStringLengthLessThanMaxLength_ReturnsOriginalString()
    {
        // Arrange
        const string testString = "Hi";
        const int maxLength = 10;

        // Act
        var result = testString.TrimLength(maxLength);

        // Assert
        Assert.Equal(testString, result);
    }

    [Fact]
    public void TrimLength_WithStringLengthGreaterThanMaxLength_ReturnsTrimmedString()
    {
        // Arrange
        const string testString = "Hello World";
        const int maxLength = 5;
        const string expected = "Hello";

        // Act
        var result = testString.TrimLength(maxLength);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TrimLength_WithZeroMaxLength_ReturnsEmptyString()
    {
        // Arrange
        const string testString = "Hello";
        const int maxLength = 0;

        // Act
        var result = testString.TrimLength(maxLength);

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Theory]
    [InlineData("Hello World", 3, "Hel")]
    [InlineData("Test", 2, "Te")]
    [InlineData("A", 1, "A")]
    [InlineData("Programming", 7, "Program")]
    public void TrimLength_WithVariousInputs_ReturnsExpectedResults(string input, int maxLength, string expected)
    {
        // Act
        var result = input.TrimLength(maxLength);

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region ReverseSubstring Tests

    [Fact]
    public void ReverseSubstring_WithNullString_ReturnsNull()
    {
        // Arrange
        string? nullString = null;

        // Act
        var result = nullString?.ReverseSubstring();

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ReverseSubstring_WithEmptyString_ReturnsEmptyString()
    {
        // Arrange
        const string emptyString = "";

        // Act
        var result = emptyString.ReverseSubstring();

        // Assert
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ReverseSubstring_WithDefaultCount_ReturnsLastCharacter()
    {
        // Arrange
        const string testString = "Hello";
        const string expected = "o";

        // Act
        var result = testString.ReverseSubstring();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReverseSubstring_WithCountEqualToStringLength_ReturnsOriginalString()
    {
        // Arrange
        const string testString = "Hello";
        const int count = 5;

        // Act
        var result = testString.ReverseSubstring(count);

        // Assert
        Assert.Equal(testString, result);
    }

    [Fact]
    public void ReverseSubstring_WithCountGreaterThanStringLength_ReturnsOriginalString()
    {
        // Arrange
        const string testString = "Hi";
        const int count = 10;

        // Act
        var result = testString.ReverseSubstring(count);

        // Assert
        Assert.Equal(testString, result);
    }

    [Fact]
    public void ReverseSubstring_WithValidCount_ReturnsLastNCharacters()
    {
        // Arrange
        const string testString = "Hello World";
        const int count = 5;
        const string expected = "World";

        // Act
        var result = testString.ReverseSubstring(count);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReverseSubstring_WithSingleCharacterString_ReturnsSameCharacter()
    {
        // Arrange
        const string testString = "A";
        const int count = 1;

        // Act
        var result = testString.ReverseSubstring(count);

        // Assert
        Assert.Equal(testString, result);
    }

    [Theory]
    [InlineData("Hello World", 1, "d")]
    [InlineData("Hello World", 3, "rld")]
    [InlineData("Programming", 4, "ming")]
    [InlineData("Test", 2, "st")]
    [InlineData("C#", 1, "#")]
    public void ReverseSubstring_WithVariousInputs_ReturnsExpectedResults(string input, int count, string expected)
    {
        // Act
        var result = input.ReverseSubstring(count);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReverseSubstring_WithZeroCount_ReturnsEmptyString()
    {
        // Arrange
        const string testString = "Hello";
        const int count = 0;

        // Act
        var result = testString.ReverseSubstring(count);

        // Assert
        Assert.Equal(string.Empty, result);
    }

    #endregion

    #region Edge Cases and Integration Tests

    [Fact]
    public void ParseString_WithObjectThatReturnsNullToString_ReturnsDefaultValue()
    {
        // Arrange
        var mockObject = new ObjectWithNullToString();
        const string customDefault = "fallback";

        // Act
        var result = mockObject.ParseString(customDefault);

        // Assert
        Assert.Equal(customDefault, result);
    }

    [Fact]
    public void TrimLength_WithUnicodeCharacters_HandlesCorrectly()
    {
        // Arrange
        const string testString = "Hello ?? World";
        const int maxLength = 8;
        const string expected = "Hello ??";

        // Act
        var result = testString.TrimLength(maxLength);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ReverseSubstring_WithUnicodeCharacters_HandlesCorrectly()
    {
        // Arrange
        const string testString = "Hello ?? World";
        const int count = 6;
        const string expected = " World";

        // Act
        var result = testString.ReverseSubstring(count);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CombinedOperations_ParseStringThenTrimLength_WorksCorrectly()
    {
        // Arrange
        const int number = 123456789;
        const int maxLength = 5;
        const string expected = "12345";

        // Act
        var result = number.ParseString().TrimLength(maxLength);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void CombinedOperations_ParseStringThenReverseSubstring_WorksCorrectly()
    {
        // Arrange
        const double number = 123.456;
        const int count = 3;
        const string expected = "456";

        // Act
        var result = number.ParseString().ReverseSubstring(count);

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region Helper Classes

    /// <summary>
    /// Test helper class that returns null from ToString() method.
    /// </summary>
    private class ObjectWithNullToString
    {
        public override string? ToString()
        {
            return null;
        }
    }

    #endregion
}