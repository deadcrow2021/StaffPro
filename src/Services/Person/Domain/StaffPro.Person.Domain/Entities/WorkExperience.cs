using StaffPro.Person.Domain.ValueObjects;
using StaffPro.Person.Domain.Exceptions;

namespace StaffPro.Person.Domain.Entities;

/// <summary>
/// Опыт работы
/// </summary>
public class WorkExperience
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Должность
    /// </summary>
    public string Position { get; private set;}

    /// <summary>
    /// Организация
    /// </summary>
    public string Organization { get; private set;}

    /// <summary>
    /// Организация
    /// </summary>
    public Address Address { get; private set;}

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Дата устройства на работу
    /// </summary>
    public DateTime EmploymentDate {get; private set; }

    /// <summary>
    /// Дата увольнения
    /// </summary>
    public DateTime FiringDate {get; private set; }


    /// <summary>
    /// Конструктор класса WorkExperience
    /// </summary>
    /// <param name="position">Должность</param>
    /// <param name="organization">Организация</param>
    /// <param name="description">Описание</param>
    /// <param name="employmentDate">Дата устройства на работу</param>
    /// <param name="firingDate">Дата увольнения</param>
    /// <param name="city">Город</param>
    /// <param name="country">Страна</param>
    public WorkExperience(
            int id,
            string position,
            string organization,
            string description,
            DateTime employmentDate,
            DateTime firingDate,
            string? city = null,
            string? country = null
            )
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id should be positive integer.");
        }
        Id = id;
        SetPosition(position);
        SetOrganization(organization);
        SetDescription(description);
        SetAddress(city, country);
    
        CompareEmploymentAndFiringDates(employmentDate, firingDate);
        EmploymentDate = employmentDate;
        FiringDate = firingDate;
    }

    /// <summary>
    /// Изменить должность
    /// </summary>
    /// <param name="position">Должность</param>
    public void SetPosition(string position)
    {
        CheckParamIsNullOrEmpty(position);
        Position = CheckLength(position);
    }

    /// <summary>
    /// Изменить организацию
    /// </summary>
    /// <param name="organization">Организация</param>
    public void SetOrganization(string organization)
    {
        CheckParamIsNullOrEmpty(organization);
        Organization = CheckLength(organization);
    }

    /// <summary>
    /// Изменить Описание
    /// </summary>
    /// <param name="description">Описание</param>
    public void SetDescription(string description)
    {
        CheckParamIsNullOrEmpty(description);
        Description = description;
    }

    /// <summary>
    /// Изменить адрес
    /// </summary>
    /// <param name="city">Город</param>
    /// <param name="country">Страна</param>
    public void SetAddress(string? city = null, string? country = null)
    {
        if (city == null || country == null)
        {
            throw new ArgumentException("City and country can\'t be null.");
        }
        Address = new Address(CheckLength(city), CheckLength(country));
    }

    /// <summary>
    /// Изменить дату устройства на работу
    /// </summary>
    /// <param name="employmentDate">Дату устройства на работу</param>
    public void SetEmploymentDate(DateTime employmentDate)
    {
        CompareEmploymentAndFiringDates(employmentDate, FiringDate);
        EmploymentDate = employmentDate;
    }

    /// <summary>
    /// Изменить дату увольнения с работы
    /// </summary>
    /// <param name="firingDate">Дата увольнения</param>
    public void SetFiringDate(DateTime firingDate)
    {
        CompareEmploymentAndFiringDates(EmploymentDate, firingDate);
        FiringDate = firingDate;
    }

    private void CompareEmploymentAndFiringDates(DateTime employmentDate, DateTime firingDate)
    {
        if (employmentDate >= firingDate)
        {
            throw new ArgumentException("Firing date should be greater then Employment date.");
        }
    }

    private static string CheckLength(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException("Argument can\'t be null.");
        }

        if (str.Length > 250)
        {
            throw new LongStringException(250);
        }

        return str;
    }

    private void CheckParamIsNullOrEmpty(params string?[] args)
    {
        if (args.Any(arg => string.IsNullOrEmpty(arg)))
        {
            throw new ArgumentException("Argument can\'t be null or empty.");
        }
    }
}
