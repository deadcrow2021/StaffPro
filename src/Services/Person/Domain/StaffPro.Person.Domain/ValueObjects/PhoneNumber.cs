using System.Text.RegularExpressions;

namespace StaffPro.Person.Domain.ValueObjects;

/// <summary>
/// Класс Номер телефона сущности Person
/// </summary>
public class PhoneNumber
{
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumberStr { get; private set; }
    
    /// <summary>
    /// Конструктор класса PhoneNumber
    /// </summary>
    /// <param name="phoneNumber"></param>
    public PhoneNumber(string phoneNumber)
    {
        PhoneNumberStr = ValidatePhoneNumber(phoneNumber);
    }


    private static string ValidatePhoneNumber(string phoneNumber)
    {
        if ( !Regex.IsMatch(phoneNumber, @"[\+7|8]\d{10}") )
        {
            throw new ArgumentException("Phone number format is not valid.");
        }

        return phoneNumber;
    }
}
