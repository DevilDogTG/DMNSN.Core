using DMNSN.Core.Extensions;

namespace DMNSN.Core.Test.Extensions;

/// <summary>
/// Unit tests for ExceptionExtension methods.
/// </summary>
public class ExceptionExtensionTests
{
    private const string Separator = " | ";

    /// <summary>
    /// Tests that GetMessage returns the message for a single exception.
    /// </summary>
    [Fact]
    public void GetMessage_WithSingleException_ReturnsMessage()
    {
        // Arrange
        var ex = new Exception("Test Exception");

        // Act
        var result = ex.GetMessage();

        // Assert
        Assert.Equal("Test Exception", result);
    }

    /// <summary>
    /// Tests that GetMessage returns concatenated messages for inner exceptions with default separator.
    /// </summary>
    [Fact]
    public void GetMessage_WithInnerExceptionAndDefaultSeparator_ReturnsConcatenatedMessages()
    {
        // Arrange
        var inner = new Exception("Inner Exception");
        var outer = new Exception("Outer Exception", inner);

        // Act
        var result = outer.GetMessage();

        // Assert
        Assert.Contains("Outer Exception", result);
        Assert.Contains("Inner Exception", result);
        Assert.Contains(" ===>>> Inner Exception ===>>> ", result);
    }

    /// <summary>
    /// Tests that GetMessage returns concatenated messages with custom separator.
    /// </summary>
    [Fact]
    public void GetMessage_WithInnerExceptionAndCustomSeparator_ReturnsConcatenatedMessagesWithSeparator()
    {
        // Arrange
        var inner = new Exception("Inner");
        var outer = new Exception("Outer", inner);

        // Act
        var result = outer.GetMessage(true, Separator);

        // Assert
        Assert.Equal("Outer | Inner", result);
    }

    /// <summary>
    /// Tests that GetMessage returns only the outer message when getInner is false.
    /// </summary>
    [Fact]
    public void GetMessage_WithInnerExceptionAndGetInnerFalse_ReturnsOnlyOuterMessage()
    {
        // Arrange
        var inner = new Exception("Inner");
        var outer = new Exception("Outer", inner);

        // Act
        var result = outer.GetMessage(false);

        // Assert
        Assert.Equal("Outer", result);
    }

    /// <summary>
    /// Tests that GetMessageUrlEncoded returns URL-encoded string.
    /// </summary>
    [Fact]
    public void GetMessageUrlEncoded_ReturnsUrlEncodedString()
    {
        // Arrange
        var ex = new Exception("Test Exception");

        // Act
        var result = ex.GetMessageUrlEncoded();

        // Assert
        Assert.Equal("Test+Exception", result);
    }

    /// <summary>
    /// Tests that GetStackTrace returns stack trace for a single exception.
    /// </summary>
    [Fact]
    public void GetStackTrace_WithSingleException_ReturnsStackTrace()
    {
        // Arrange
        Exception ex;
        try
        {
            throw new Exception("Test");
        }
        catch (Exception e)
        {
            ex = e;
        }

        // Act
        var result = ex.GetStackTrace();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    /// <summary>
    /// Tests that GetStackTrace returns combined stack trace for inner exceptions.
    /// </summary>
    [Fact]
    public void GetStackTrace_WithInnerException_ReturnsCombinedStackTrace()
    {
        // Arrange
        Exception outer;
        try
        {
            try
            {
                throw new Exception("Inner");
            }
            catch (Exception inner)
            {
                throw new Exception("Outer", inner);
            }
        }
        catch (Exception e)
        {
            outer = e;
        }

        // Act
        var result = outer.GetStackTrace(true, Separator);

        // Assert
        Assert.NotNull(result);
        Assert.Contains(Separator, result);
    }
}
