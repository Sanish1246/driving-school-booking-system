using System.Text.RegularExpressions;
using System.Globalization;
using MainProject.Context;
namespace MainProject;

public class Validations
{
    public static bool ValidateString(string text) => !string.IsNullOrEmpty(text);

    public static bool ValidateLettersOnly(string text)
    {
        var textRegex = new Regex(@"^[a-zA-Z]+$");
        return textRegex.IsMatch(text);
    }
    
    // Remove all white space characters
    public static string RemoveWhiteSpaces(string text)
    {
        var spaceRegex = new Regex(@"\s+");
        text = spaceRegex.Replace(text, "");
        return text;
    }

    public static  bool ValidateEmail(string email)
    {
        var emailRegex = new Regex(@"\w+@[a-zA-Z\.]+\.\w+");
        return emailRegex.IsMatch(email);
    }

    public static bool ValidatePassword(string password)
    {
        var passwordRegex = new Regex(@"(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&*\(\)\-\!+\?])[A-Za-z\d@#$%^&*\(\)\-\!+\?]{12,}");
        const string uppercasePattern = "(.*[A-Z])";
        const string lowercasePattern = "(.*[a-z])";
        const string digitPattern = @"(.*\d)";
        const string symbolPattern = @"(.*[@#$%^&*\(\)\-\!+\?])";
        const string lengthPattern = @"([A-Za-z\d@#$%^&*\(\)\-\!+\?]{12,})";

        var containUpperCase = Regex.IsMatch(password, uppercasePattern);
        var containLowerCase = Regex.IsMatch(password, lowercasePattern);
        var containDigit = Regex.IsMatch(password, digitPattern);
        var containSymbol = Regex.IsMatch(password, symbolPattern);
        var validLength = Regex.IsMatch(password, lengthPattern);

        if (!containUpperCase) Console.WriteLine("Password should contain at least one uppercase letter.");
        if (!containLowerCase) Console.WriteLine("Password should contain at least one lowercase letter.");
        if (!containDigit) Console.WriteLine("Password should contain at least one digit.");
        if (!containSymbol) Console.WriteLine("Password should contain at least one special character.");
        if (!validLength) Console.WriteLine("Password is too short, it should be at least 12 characters long.");

        return passwordRegex.IsMatch(password);
    }

    public static bool ValidateDate(string date)
    {
        var format = "yyyy/MM/dd";
        return DateOnly.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }

    public static bool ValidatePhoneNumber(string phoneNumber)
    {
        var phoneNumberRegex = new Regex(@"(\(\+\d+\))?((\s+)?\d{8})");
        return phoneNumberRegex.IsMatch(phoneNumber.Trim());
    }
    
}