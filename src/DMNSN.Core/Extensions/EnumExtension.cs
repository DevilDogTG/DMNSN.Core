using System.ComponentModel;
using System.Reflection;

namespace DMNSN.Core.Extensions;
/// <summary>
/// Provides extension methods for working with enumeration types.
/// </summary>
/// <remarks>This static class includes methods for retrieving metadata associated with enumeration values, such
/// as descriptions and custom attributes, as well as utility methods for converting enumeration values to their
/// underlying integer representations. These methods leverage reflection to access metadata and provide additional
/// functionality for working with enumerations in .NET.</remarks>
public static class EnumExtension
{
    /// <summary>
    /// Retrieves the description associated with an enumeration value, if a <see cref="DescriptionAttribute"/> is
    /// applied.
    /// </summary>
    /// <remarks>This method uses reflection to retrieve the <see cref="DescriptionAttribute"/> applied to the
    /// specified enumeration value. If no such attribute is present, the method returns <see
    /// langword="null"/>.</remarks>
    /// <param name="value">The enumeration value for which to retrieve the description.</param>
    /// <returns>The description specified in the <see cref="DescriptionAttribute"/> applied to the enumeration value, or <see
    /// langword="null"/> if no description is found.</returns>
    public static string? Description(this Enum value)
    {
        FieldInfo? fieldInfo = value
            .GetType()
            .GetField(value.ToString());
        if (fieldInfo == null) return null;
        var attribute = (DescriptionAttribute?)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
        return attribute?.Description;
    }

    /// <summary>
    /// Retrieves a custom attribute of the specified type that is applied to the field of the given enumeration value.
    /// </summary>
    /// <remarks>This method uses reflection to retrieve the custom attribute applied to the field of the
    /// specified enumeration value. If the enumeration value does not have the specified attribute, the method returns
    /// <see langword="null"/>.</remarks>
    /// <typeparam name="TAttribute">The type of the attribute to retrieve. Must derive from <see cref="Attribute"/>.</typeparam>
    /// <param name="value">The enumeration value whose associated field's attribute is to be retrieved.</param>
    /// <returns>An instance of <typeparamref name="TAttribute"/> if the attribute is found; otherwise, <see langword="null"/>.</returns>
    public static TAttribute? GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name == null) return null;
        return type.GetField(name)?.GetCustomAttribute<TAttribute>();
    }

    /// <summary>
    /// Converts the specified enumerated value to its underlying integer representation.
    /// </summary>
    /// <typeparam name="T">The type of the enumerated value. Must implement <see cref="IConvertible"/> and be an enumeration type.</typeparam>
    /// <param name="soure">The enumerated value to convert.</param>
    /// <returns>The integer representation of the specified enumerated value.</returns>
    /// <exception cref="ArgumentException">Thrown if <typeparamref name="T"/> is not an enumerated type.</exception>
    public static int ToInt<T>(this T soure) where T : IConvertible
    {
        if (!typeof(T).IsEnum)
        { throw new ArgumentException("T must be an enumerated type"); }

        return (int)(IConvertible)soure;
    }
}
