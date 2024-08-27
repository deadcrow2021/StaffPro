namespace StaffPro.Person.Domain.ValueObjects;

/// <summary>
/// Класс ФИО сущности Person
/// </summary>
public class Address
{
    /// <summary>
    /// Имя
    /// </summary>
    public string? City { get; private set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string? Country { get; private set; }

    /// <summary>
    /// Конструктор класса Адреса
    /// </summary>
    /// <param name="city"></param>
    /// <param name="country"></param>
    public Address(string? city = null, string? country = null)
    {
        City = city;
        Country = country;
    }

    /// <summary>
    /// Обновить город
    /// </summary>
    /// <param name="city"></param>
    public void ChangeCity(string city)
    {
        City = city;
    }

    /// <summary>
    /// Обновить страну
    /// </summary>
    /// <param name="country"></param>
    public void ChangeCountry(string country)
    {
        Country = country;
    }
}
