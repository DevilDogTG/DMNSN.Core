using DMNSN.Core.Extensions;

namespace DMNSN.Core.Test.Extensions;

public class ExceptionExtensionTests
{
    private const string Separator = " | ";

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
