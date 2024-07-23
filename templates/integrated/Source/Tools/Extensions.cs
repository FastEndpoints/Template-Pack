using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MyProject;

static class Extensions
{
    static readonly TextInfo _txt = CultureInfo.InvariantCulture.TextInfo;

    internal static string TitleCase(this string value)
        => _txt.ToTitleCase(value.Trim());

    internal static string LowerCase(this string value)
        => _txt.ToLower(value.Trim());

    internal static string UpperCase(this string value)
        => _txt.ToUpper(value.Trim());

    internal static bool HasValue([NotNullWhen(true)] this string? value)
        => !string.IsNullOrEmpty(value);

    internal static bool HasNoValue([NotNullWhen(false)] this string? value)
        => string.IsNullOrEmpty(value);

    internal static bool IsAValidMobileNumber(this string phoneNumber)
        => phoneNumber.Length == 10;

    internal static bool IsAValidBirthDay(this string birthday)
    {
        if (!DateTime.TryParse(birthday, out var birthDate))
            return false;

        var currentDate = DateTime.UtcNow;
        var age = currentDate.Year - birthDate.Year;

        if (birthDate > currentDate || age < 18)
            return false;

        if (birthDate > currentDate.AddYears(-age))
            age--;

        return age >= 18;
    }

    internal static bool IsAValidGender(this string gender)
        => gender is "Male" or "Female" or "Other";

    internal static string PasswordHash(this string value)
        => BCrypt.Net.BCrypt.HashPassword(value);

    internal static bool IsValidPasswordForHash(this string password, string passwordHash)
        => BCrypt.Net.BCrypt.Verify(password, passwordHash);

    internal static bool IsAValidPassword(this string password)
    {
        const int minLength = 8;
        const int maxLength = 20;

        if (string.IsNullOrEmpty(password))
            return false;

        var meetsLengthRequirements = password.Length is >= minLength and <= maxLength;
        var hasUpperCaseLetter = false;
        var hasLowerCaseLetter = false;
        var hasDecimalDigit = false;

        if (!meetsLengthRequirements)
        {
            return meetsLengthRequirements &&
                   hasUpperCaseLetter &&
                   hasLowerCaseLetter &&
                   hasDecimalDigit;
        }

        foreach (var c in password)
        {
            if (char.IsUpper(c))
                hasUpperCaseLetter = true;
            else if (char.IsLower(c))
                hasLowerCaseLetter = true;
            else if (char.IsDigit(c))
                hasDecimalDigit = true;
        }

        return meetsLengthRequirements &&
               hasUpperCaseLetter &&
               hasLowerCaseLetter &&
               hasDecimalDigit;
    }
}