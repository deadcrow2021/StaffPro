namespace StaffPro.Person.Domain.Entities.WorkExperienceInfo;

/// <summary>
/// Класс ФИО сущности Person
/// </summary>
public class Address
{
    /// <summary>
    /// Имя
    /// </summary>
    public string City { get; private set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string Country { get; private set; }

    /// <summary>
    /// Конструктор класса Адреса
    /// </summary>
    /// <param name="city"></param>
    /// <param name="country"></param>
    public Address(string city = "", string country = "")
    {
        City = ValidateAddress(city);
        Country = ValidateAddress(country);
    }

    /// <summary>
    /// Обновить город
    /// </summary>
    /// <param name="city"></param>
    public void ChangeCity(string city)
    {
        City = ValidateAddress(city);
    }

    /// <summary>
    /// Обновить страну
    /// </summary>
    /// <param name="country"></param>
    public void ChangeCountry(string country)
    {
        Country = ValidateAddress(country);
    }

    private static string ValidateAddress(string address)
    {
        if (address.Length > 250)
        {
            throw new ArgumentException("Address is too long.");
        }

        return address;
    }
}
