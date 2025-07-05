namespace DMNSN.Core.Extensions;

public partial class ConvertExtension
{
    /// <summary>
    /// Converts the specified object to its string representation, or returns a default value if the object is null.
    /// </summary>
    /// <param name="ob">The object to convert to a string. If <see langword="null"/>, the <paramref name="defaultValue"/> is returned.</param>
    /// <param name="defaultValue">The default string value to return if <paramref name="ob"/> is <see langword="null"/> or its string
    /// representation is <see langword="null"/>. Defaults to an empty string.</param>
    /// <returns>The string representation of <paramref name="ob"/>, or <paramref name="defaultValue"/> if <paramref name="ob"/>
    /// is <see langword="null"/> or its string representation is <see langword="null"/>.</returns>
    public static string ParseString(this object ob, string defaultValue = "")
    {
        string rs = defaultValue;
        if (ob != null) { rs = Convert.ToString(ob) ?? defaultValue; }
        return rs;
    }

    /// <summary>
    /// Trims the input string to the specified maximum length.
    /// </summary>
    /// <remarks>If the input string is <see langword="null"/> or empty, the method returns it
    /// unchanged.</remarks>
    /// <param name="s">The input string to be trimmed. Can be null or empty.</param>
    /// <param name="maxLength">The maximum number of characters to retain in the string. Must be a non-negative value.</param>
    /// <returns>The original string if its length is less than or equal to <paramref name="maxLength"/>; otherwise, a substring
    /// containing the first <paramref name="maxLength"/> characters.</returns>
    public static string TrimLength(this string s, int maxLength)
    {
        if (string.IsNullOrEmpty(s))
        { return s; }
        return s.Length <= maxLength ? s : s.Substring(0, maxLength);
    }

    /// <summary>
    /// Returns a substring containing the specified number of characters from the end of the input string.
    /// </summary>
    /// <param name="s">The input string from which the substring is extracted. Cannot be <see langword="null"/>.</param>
    /// <param name="count">The number of characters to include in the substring, starting from the end of the string. Defaults to 1. Must
    /// be less than or equal to the length of the string.</param>
    /// <returns>A substring containing the last <paramref name="count"/> characters of the input string.  If <paramref
    /// name="s"/> is <see langword="null"/> or empty, or if <paramref name="count"/> is greater than or equal to the
    /// length of the string, the original string is returned.</returns>
    public static string ReverseSubstring(this string s, int count = 1)
    {
        if (string.IsNullOrEmpty(s) || s.Length <= count)
        { return s; }
        return s.Substring(s.Length - count, count);
    }
}
