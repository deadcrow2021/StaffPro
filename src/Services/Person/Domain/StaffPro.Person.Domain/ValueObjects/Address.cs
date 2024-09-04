namespace StaffPro.Person.Domain.ValueObjects;

/// <summary>
/// Класс ФИО сущности Person
/// </summary>
public class Address
{
    /// <summary>
    /// Город
    /// </summary>
    public string? City { get; private set; }

    /// <summary>
    /// Страна
    /// </summary>
    public string? Country { get; private set; }

    /// <summary>
    /// Конструктор класса Адреса
    /// </summary>
    /// <param name="city">Город</param>
    /// <param name="country">Страна</param>
    public Address(string? city = null, string? country = null)
    {
        City = city;
        Country = country;
    }
}
