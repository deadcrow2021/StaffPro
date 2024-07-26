using System.Reflection.Metadata.Ecma335;

namespace StaffPro.Person.Domain.Entities.PersonInfo;

/// <summary>
/// Дата рождения сущности Person
/// </summary>
public class BirthDay
{
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDate { get; private set; }

    /// <summary>
    /// Конструктор класса BirthDay
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    public BirthDay(int day, int month, int year)
    {
        BirthDate = new DateTime(year, month, day);
    }

    /// <summary>
    /// Изменение даты рождения
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    public void ChangeBirthDate(int day, int month, int year)
    {
        BirthDate = new DateTime(year, month, day);
    }

    /// <summary>
    /// Получение даты рождения в формате "dd.MM.yyyy"
    /// </summary>
    public string GetFormatedBirthDate()
    {
        return BirthDate.Date.ToString("dd.MM.yyyy");
    }
}
