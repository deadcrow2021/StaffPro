using System.Text.RegularExpressions;
using System.Globalization;
using StaffPro.Person.Domain.Exceptions;

namespace StaffPro.Person.Domain.ValueObjects;

/// <summary>
/// Класс Email сущности Person
/// </summary>
public class Email
{
    /// <summary>
    /// Email
    /// </summary>
    public string EmailAddress { get; private set; }

    /// <summary>
    /// Конструктор класса Email
    /// </summary>
    /// <param name="email"></param>
    public Email(string email)
    {
        EmailAddress = ValidateEmail(email);
    }


    private static string ValidateEmail(string email)
    {
        if (email.Length > 255)
        {
            throw new LongStringException(255);
        }

        if (!IsValidEmailFormat(email))
        {
            throw new ArgumentException("Email string is not valid format.");
        }

        return email;
    }


    private static bool IsValidEmailFormat(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            // Normalize the domain
            email = Regex.Replace(
                        email,
                        @"(@)(.+)$",
                        DomainMapper,
                        RegexOptions.None,
                        TimeSpan.FromMilliseconds(200)
                    );

            // Examines the domain part of the email and normalizes it.
            static string DomainMapper(Match match)
            {
                // Use IdnMapping class to convert Unicode domain names.
                var idn = new IdnMapping();

                // Pull out and process domain name (throws ArgumentException on invalid)
                string domainName = idn.GetAscii(match.Groups[2].Value);

                return match.Groups[1].Value + domainName;
            }
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        try
        {
            return Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }


    /// <summary>
    /// Обновить email
    /// </summary>
    /// <param name="email"></param>
    public void ChangeEmail(string email)
    {
        EmailAddress = ValidateEmail(email);
    }
}