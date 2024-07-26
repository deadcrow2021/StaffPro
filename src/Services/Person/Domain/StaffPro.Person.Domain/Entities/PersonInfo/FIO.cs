using System.Text.RegularExpressions;


namespace StaffPro.Person.Domain.Entities.PersonInfo;

/// <summary>
/// Класс ФИО сущности Person
/// </summary>
public class FIO
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
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="patronymic"></param>
    public FIO(string firstName, string lastName, string patronymic)
    {
        FirstName = ValidateName(firstName);
        LastName = ValidateName(lastName);
        Patronymic = ValidateName(patronymic);
    }

    private static string ValidateName(string nameStr)
    {
        if (nameStr.Length < 3 || nameStr.Length > 60)
        {
            throw new ArgumentException("Name string is too short or too long.");
        }

        if ( !Regex.IsMatch(nameStr, @"^[a-zA-Z]+$") ) {
            throw new ArgumentException("Name string is not valid. Only letters allowed.");
        }

        return nameStr;
    }

    /// <summary>
    /// Обновить имя
    /// </summary>
    /// <param name="nameStr"></param>
    public void ChangeFirstName(string nameStr)
    {
        FirstName = ValidateName(nameStr);
    }

    /// <summary>
    /// Обновить фамилию
    /// </summary>
    /// <param name="nameStr"></param>
    public void ChangeLastName(string nameStr)
    {
        LastName = ValidateName(nameStr);
    }

    /// <summary>
    /// Обновить отчество
    /// </summary>
    /// <param name="nameStr"></param>
    public void ChangePatronymic(string nameStr)
    {
        Patronymic = ValidateName(nameStr);
    }
}
