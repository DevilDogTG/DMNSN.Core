namespace DMNSN.Core.Extensions;

public static partial class ConvertExtension
{
    /// <summary>
    /// Represents a collection of string values that are interpreted as "true" in a case-insensitive manner.
    /// </summary>
    /// <remarks>This collection is used to standardize the interpretation of various string inputs as boolean
    /// true values. The comparison is performed using <see cref="StringComparer.OrdinalIgnoreCase"/> to ensure
    /// case-insensitive matching.</remarks>
    private static readonly HashSet<string> TrueValues = new(StringComparer.OrdinalIgnoreCase)
    {
        "y", "yes", "true", "1"
    };

    /// <summary>
    /// Parses the specified string and determines whether it represents a boolean "true" value.
    /// </summary>
    /// <param name="s">The string to evaluate. Leading and trailing whitespace is ignored.</param>
    /// <returns><see langword="true"/> if the trimmed string matches a predefined set of "true" values;  otherwise, <see
    /// langword="false"/>. Returns <see langword="false"/> if the input is null, empty, or consists only of whitespace.</returns>
    public static bool ParseBoolean(this string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        { return false; }
        
        return TrueValues.Contains(s.Trim());
    }
}

