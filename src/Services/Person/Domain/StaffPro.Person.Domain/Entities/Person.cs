using StaffPro.Person.Domain.ValueObjects;
using StaffPro.Person.Domain.Enums;

namespace StaffPro.Person.Domain.Entities;

/// <summary>
/// Сущность Person
/// </summary>
public class Person
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public FullName FullName { get; private set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public Email Email { get; private set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public PhoneNumber PhoneNumber { get; private set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDay { get; set; }
    
    /// <summary>
    /// URL аватара
    /// </summary>
    public Avatar Avatar { get; private set; }

    /// <summary>
    /// Пол
    /// </summary>
    public eGender Gender { get; private set; }
    
    /// <summary>
    /// Замечание/Комментарий
    /// </summary>
    public string? Comment { get; set; }
    
    /// <summary>
    /// Список опыта работы
    /// </summary>
    public List<WorkExperience> WorkExperiences { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="patronymic"></param>
    /// <param name="email"></param>
    /// <param name="phoneNumber"></param>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    /// <param name="avatar"></param>
    /// <param name="gender"></param>
    /// <param name="comment"></param>
    public Person(
        int id,
        string firstName,
        string lastName,
        string patronymic,
        string email,
        string phoneNumber,
        int day,
        int month,
        int year,
        string avatar,
        eGender gender,
        string? comment = null
        )
    {
        Id = id;
        FullName = new(firstName, lastName, patronymic);
        Email = new(email);
        PhoneNumber = new(phoneNumber);
        BirthDay = new(year, month, day);
        Avatar = new(avatar);
        Gender = gender;
        Comment = comment;
        WorkExperiences = [];
    }

    /// <summary>
    /// Изменить ФИО сущности Person
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="patronymic"></param>
    public void SetFullName(string firstName, string lastName, string patronymic)
    {
        FullName = new(firstName, lastName, patronymic);
    }

    /// <summary>
    /// Изменить Email
    /// </summary>
    /// <param name="email"></param>
    public void SetEmail(string email)
    {
        Email = new(email);
    }

    /// <summary>
    /// Изменить Номер телефона
    /// </summary>
    /// <param name="phoneNumber"></param>
    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = new(phoneNumber);
    }

    /// <summary>
    /// Изменить ссылку на аватар
    /// </summary>
    /// <param name="avatar"></param>
    public void SetAvatar(string avatar)
    {
        Avatar = new(avatar);
    }
    
    /// <summary>
    /// Изменить пол
    /// </summary>
    /// <param name="gender"></param>
    public void SetGender(eGender gender)
    {
        Gender = gender;
    }

    /// <summary>
    /// Получить сущность WorkExperience по книальному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public WorkExperience? GetWorkExperienceById(int id)
    {
        return WorkExperiences.FirstOrDefault(we => we.Id == id);
    }

    /// <summary>
    /// Добавить сущность WorkExperience
    /// </summary>
    /// <param name="id"></param>
    /// <param name="position"></param>
    /// <param name="organization"></param>
    /// <param name="description"></param>
    /// <param name="employmentDate"></param>
    /// <param name="firingDate"></param>
    /// <param name="city"></param>
    /// <param name="country"></param>
    public void AddWorkExperience(
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
        WorkExperience workExperience = new(
            id,
            position,
            organization,
            description,
            employmentDate,
            firingDate,
            city,
            country
            );
        WorkExperiences.Add(workExperience);
    }

    /// <summary>
    /// Удалить сущность WorkExperience по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteWorkExperienceById(int id)
    {
        WorkExperience? we = GetWorkExperienceById(id);
        if (we == null)
        {
            return false;
        }
        else
        {
            WorkExperiences.Remove(we);
            return true;
        }
    }
    
}
