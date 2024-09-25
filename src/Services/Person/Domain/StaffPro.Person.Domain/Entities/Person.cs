using StaffPro.Person.Domain.ValueObjects;
using StaffPro.Person.Domain.Exceptions;
using StaffPro.Person.Domain.Enums;
using System.ComponentModel.DataAnnotations;

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
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="patronymic">Отчество</param>
    /// <param name="email">Email</param>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <param name="birthDate">Дата рождения</param>
    /// <param name="avatar">URL аватара</param>
    /// <param name="gender">Пол</param>
    /// <param name="comment">Замечание/Комментарий</param>
    public Person(
        int id,
        string firstName,
        string lastName,
        string patronymic,
        string email,
        string phoneNumber,
        DateTime birthDate,
        string avatar,
        eGender gender,
        string? comment = null
        )
    {
        if (id <= 0)
        {
            throw new ArgumentException("Id should be positive integer.");
        }
        Id = id;
        
        CheckParamIsNullOrEmpty(firstName, lastName, patronymic, email, phoneNumber, avatar, comment);
        SetFullName(firstName, lastName, patronymic);
        SetEmail(email);
        SetPhoneNumber(phoneNumber);
        SetBirthDay(birthDate);
        SetAvatar(avatar);
        SetGender(gender);
        Comment = comment;
        WorkExperiences = new List<WorkExperience>();
    }

    /// <summary>
    /// Изменить ФИО сущности Person
    /// </summary>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="patronymic">Отчество</param>
    public void SetFullName(string firstName, string lastName, string patronymic)
    {
        CheckParamIsNullOrEmpty(firstName, lastName, patronymic);
        FullName = new(firstName, lastName, patronymic);
    }

    /// <summary>
    /// Изменить Email
    /// </summary>
    /// <param name="email">Email</param>
    public void SetEmail(string email)
    {
        CheckParamIsNullOrEmpty(email);
        Email = new(email);
    }

    /// <summary>
    /// Изменить Номер телефона
    /// </summary>
    /// <param name="phoneNumber">Номер телефона</param>
    public void SetPhoneNumber(string phoneNumber)
    {
        CheckParamIsNullOrEmpty(phoneNumber);
        PhoneNumber = new(phoneNumber);
    }

    /// <summary>
    /// Изменить Дату Рождения
    /// </summary>
    /// <param name="birthDate">Дата рождения</param>
    public void SetBirthDay(DateTime birthDate)
    {
        BirthDay = birthDate;
    }

    /// <summary>
    /// Изменить ссылку на аватар
    /// </summary>
    /// <param name="avatar">URL аватара</param>
    public void SetAvatar(string avatar)
    {
        CheckParamIsNullOrEmpty(avatar);
        Avatar = new(avatar);
    }
    
    /// <summary>
    /// Изменить пол
    /// </summary>
    /// <param name="gender">Пол</param>
    public void SetGender(eGender gender)
    {
        Gender = gender;
    }

    /// <summary>
    /// Получить сущность WorkExperience по книальному идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Сущность WorkExperience</returns>
    public WorkExperience? GetWorkExperienceById(int id)
    {
        return WorkExperiences.FirstOrDefault(we => we.Id == id, null);
    }

    /// <summary>
    /// Добавить сущность WorkExperience
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="position">Должность</param>
    /// <param name="organization">Организация</param>
    /// <param name="description">Описание</param>
    /// <param name="employmentDate">Дата устройства на работу</param>
    /// <param name="firingDate">Дата увольнения</param>
    /// <param name="city">Город</param>
    /// <param name="country">Страна</param>
    public void AddWorkExperience(
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
        if (WorkExperiences.Any(x => x.Id == id))
        {
            throw new EntityExistsException("WorkExperience", id);
        }
        WorkExperiences.Add(workExperience);
    }

    /// <summary>
    /// Удалить сущность WorkExperience по id
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <returns>Результат удаления сущности WorkExperience</returns>
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

    private void CheckParamIsNullOrEmpty(params string?[] args)
    {
        if (args.Any(arg => string.IsNullOrEmpty(arg)))
        {
            throw new ArgumentException("Argument can\'t be null or empty");
        }
    }
}
