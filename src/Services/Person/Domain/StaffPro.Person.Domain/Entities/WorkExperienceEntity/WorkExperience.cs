using StaffPro.Person.Domain.Entities.WorkExperienceInfo;

namespace StaffPro.Person.Domain.Entities.WorkExperienceEntity;

public class WorkExperience
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; private set; }

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
    public Address JobAddress { get; private set;}

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
    /// <param name="position"></param>
    /// <param name="organization"></param>
    /// <param name="description"></param>
    /// <param name="employmentDate"></param>
    /// <param name="firingDate"></param>
    /// <param name="city"></param>
    /// <param name="country"></param>
    public WorkExperience(
            int id,
            string position,
            string organization,
            string description,
            DateTime employmentDate,
            DateTime firingDate,
            string city = "",
            string country = ""
            )
    {
        ID = id;
        Position = CheckLength(position);
        Organization = organization;
        Description = description;
        JobAddress = new Address(city, country);
    
        CompareEmploymentAndFiringDates(employmentDate, firingDate);
        EmploymentDate = employmentDate;
        FiringDate = firingDate;
    }

    /// <summary>
    /// Изменить должность
    /// </summary>
    /// <param name="position"></param>
    public void SetPosition(string position)
    {
        Position = CheckLength(position);
    }

    /// <summary>
    /// Изменить организацию
    /// </summary>
    /// <param name="organization"></param>
    public void SetOrganization(string organization)
    {
        Position = CheckLength(organization);
    }

    /// <summary>
    /// Изменить Описание
    /// </summary>
    /// <param name="description"></param>
    public void SetDescription(string description)
    {
        Position = description;
    }

    /// <summary>
    /// Изменить адрес
    /// </summary>
    /// <param name="city"></param>
    /// <param name="country"></param>
    public void SetAddress(string city, string country)
    {
        JobAddress = new Address(city, country);
    }

    /// <summary>
    /// Изменить дату устройства на работу
    /// </summary>
    /// <param name="employmentDate"></param>
    public void SetEmploymentDate(DateTime employmentDate)
    {
        CompareEmploymentAndFiringDates(employmentDate, FiringDate);
        EmploymentDate = employmentDate;
    }

    /// <summary>
    /// Изменить дату увольнения с работы
    /// </summary>
    /// <param name="firingDate"></param>
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

    private static string CheckLength(string position)
    {
        if (position.Length > 250)
        {
            throw new ArgumentException("Property is too long");
        }

        return position;
    }
}
