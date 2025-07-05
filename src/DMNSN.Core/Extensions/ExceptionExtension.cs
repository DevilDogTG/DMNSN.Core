using System.Web;

namespace DMNSN.Core.Extensions;

/// <summary>
/// Provides extension methods for working with <see cref="Exception"/> objects,  including retrieving detailed messages
/// and stack traces, with optional support  for inner exceptions and URL encoding.
/// </summary>
/// <remarks>These extension methods are designed to simplify the process of extracting  and formatting exception
/// details, particularly in scenarios where inner  exceptions need to be included or the output needs to be URL-encoded
/// for  transmission or logging purposes.</remarks>
public static class ExceptionExtension
{
    private const string INNER_EX_SEPARATOR = " ===>>> Inner Exception ===>>> ";
    private const string INNER_TRACE_SEPARATOR = " ===>>> Inner StackTrace ===>>> ";

    /// <summary>
    /// Retrieves the message of the specified exception, optionally including messages from inner exceptions.
    /// </summary>
    /// <param name="ex">The exception from which to retrieve the message. Cannot be <see langword="null"/>.</param>
    /// <param name="getInner">A value indicating whether to include messages from inner exceptions.  <see langword="true"/> to include inner
    /// exception messages; otherwise, <see langword="false"/>.</param>
    /// <param name="inSeparator">The string used to separate messages from the exception and its inner exceptions.  Defaults to a predefined
    /// separator if not specified.</param>
    /// <returns>A concatenated string containing the message of the exception and, if <paramref name="getInner"/> is  <see
    /// langword="true"/>, the messages of its inner exceptions. Returns an empty string if <paramref name="ex"/> is
    /// <see langword="null"/>.</returns>
    public static string GetMessage(this Exception ex, bool getInner = true, string inSeparator = INNER_EX_SEPARATOR)
    {
        string rs = string.Empty;
        if (ex != null)
        {
            rs += ex.Message;
            if (getInner && ex.InnerException != null)
            {
                rs += string.Format("{0}{1}",
                inSeparator,
                ex.InnerException.GetMessage(getInner, inSeparator));
            }
        }
        return rs;
    }
    /// <summary>
    /// Encodes the message of the specified exception as a URL-encoded string.
    /// </summary>
    /// <param name="ex">The exception whose message will be encoded. Cannot be <see langword="null"/>.</param>
    /// <param name="getInner">A value indicating whether to include the messages of inner exceptions.  <see langword="true"/> to include inner
    /// exception messages; otherwise, <see langword="false"/>.</param>
    /// <param name="inSeparator">The string used to separate messages when including inner exception messages.  Defaults to a predefined
    /// separator if not specified.</param>
    /// <returns>A URL-encoded string containing the exception message, and optionally the messages of inner exceptions.</returns>
    public static string GetMessageUrlEncoded(this Exception ex, bool getInner = true, string inSeparator = INNER_EX_SEPARATOR)
    { return HttpUtility.UrlEncode(ex.GetMessage(getInner, inSeparator)); }

    /// <summary>
    /// Retrieves the stack trace of the specified exception, optionally including the stack traces of inner exceptions.
    /// </summary>
    /// <param name="ex">The exception for which to retrieve the stack trace. Must not be <see langword="null"/>.</param>
    /// <param name="getInner">A value indicating whether to include the stack traces of inner exceptions.  <see langword="true"/> to include
    /// inner exception stack traces; otherwise, <see langword="false"/>.</param>
    /// <param name="inSeparator">The string used to separate stack traces when inner exceptions are included.  Defaults to a predefined separator
    /// if not specified.</param>
    /// <returns>A string containing the stack trace of the specified exception. If <paramref name="getInner"/> is  <see
    /// langword="true"/>, the stack traces of inner exceptions are appended, separated by <paramref
    /// name="inSeparator"/>. Returns an empty string if <paramref name="ex"/> is <see langword="null"/>.</returns>
    public static string GetStackTrace(this Exception ex, bool getInner = true, string inSeparator = INNER_TRACE_SEPARATOR)
    {
        string rs = string.Empty;
        if (ex != null)
        {
            rs += ex.StackTrace;
            if (getInner && ex.InnerException != null)
            { rs += string.Format("{0}{1}", inSeparator, ex.InnerException.GetStackTrace(getInner, inSeparator)); }
        }
        return rs;
    }
    /// <summary>
    /// Encodes the stack trace of the specified exception as a URL-encoded string.
    /// </summary>
    /// <param name="ex">The exception whose stack trace is to be encoded. Cannot be <see langword="null"/>.</param>
    /// <param name="getInner">A value indicating whether to include the stack trace of the inner exception.  <see langword="true"/> to include
    /// the inner exception's stack trace; otherwise, <see langword="false"/>.</param>
    /// <param name="inSeparator">The string used to separate the stack traces of the outer and inner exceptions, if <paramref name="getInner"/>
    /// is <see langword="true"/>. Defaults to a predefined separator.</param>
    /// <returns>A URL-encoded string representation of the exception's stack trace. If <paramref name="getInner"/> is <see
    /// langword="true"/>,  the inner exception's stack trace is included and separated by <paramref
    /// name="inSeparator"/>.</returns>
    public static string GetStackTraceEncoded(this Exception ex, bool getInner = false, string inSeparator = INNER_EX_SEPARATOR)
    { return HttpUtility.UrlEncode(ex.GetStackTrace(getInner, inSeparator)); }
}

