using System.Text.RegularExpressions;
using StaffPro.Person.Domain.Exceptions;

namespace StaffPro.Person.Domain.ValueObjects;

/// <summary>
/// Класс ФИО сущности Person
/// </summary>
public class FullName
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; private set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; private set; }


    /// <summary>
    /// Конструктор класса ФИО
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="patronymic">Отчество</param>
    public FullName(string firstName, string lastName, string patronymic)
    {
        FirstName = ValidateName(firstName);
        LastName = ValidateName(lastName);
        Patronymic = ValidateName(patronymic);
    }

    private static string ValidateName(string nameStr)
    {
        if (nameStr.Length < 3)
        {
            throw new ShortStringException(3);
        }

        if (nameStr.Length > 60)
        {
            throw new LongStringException(60);
        }

        if ( !Regex.IsMatch(nameStr, @"^[a-zA-Z]+$") ) {
            throw new ArgumentException("Name string is not valid. Only letters allowed.");
        }

        return nameStr;
    }
}
