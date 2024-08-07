using StaffPro.Person.Domain.Entities.WorkExperienceEntity;
using StaffPro.Person.Domain.Entities.PersonInfo;


namespace StaffPro.Person.Domain.Entities.Person;


public class Person
{
    /// <summary>
    /// ID
    /// </summary>
    public int ID { get; private set; }

    /// <summary>
    /// ФИО
    /// </summary>
    public FIO Fio { get; private set; }
    
    /// <summary>
    /// Email
    /// </summary>
    public Email EmailProp { get; private set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public PhoneNumber PhoneNumberProp { get; private set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public BirthDay BirthDayProp { get; private set; }
    
    /// <summary>
    /// URL аватара
    /// </summary>
    public Avatar AvatarUrl { get; private set; }

    /// <summary>
    /// Пол
    /// </summary>
    public Gender GenderProp { get; private set; }
    
    /// <summary>
    /// Замечание/Комментарий
    /// </summary>
    public Comment CommentProp { get; private set; }
    
    /// <summary>
    /// Список опыта работы
    /// </summary>
    public WorkExperience[] WorkExperiences { get; private set; }

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
    /// <param name="avatarURL"></param>
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
        string avatarURL,
        Gender gender,
        string comment = ""
        )
    {
        ID = id;
        Fio = new(firstName, lastName, patronymic);
        EmailProp = new(email);
        PhoneNumberProp = new(phoneNumber);
        BirthDayProp = new(day, month, year);
        AvatarUrl = new(avatarURL);
        GenderProp = gender;
        CommentProp = new(comment);
        WorkExperiences = [];
    }

    /// <summary>
    /// Изменить ФИО
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="patronymic"></param>
    public void SetFIO(string firstName, string lastName, string patronymic)
    {
        Fio = new(firstName, lastName, patronymic);
    }

    /// <summary>
    /// Изменить Email
    /// </summary>
    /// <param name="email"></param>
    public void SetEmail(string email)
    {
        EmailProp = new(email);
    }

    /// <summary>
    /// Изменить Номер телефона
    /// </summary>
    /// <param name="phoneNumber"></param>
    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumberProp = new(phoneNumber);
    }

    /// <summary>
    /// Изменить дату рождения
    /// </summary>
    /// <param name="day"></param>
    /// <param name="month"></param>
    /// <param name="year"></param>
    public void SetBirthDate(int day, int month, int year)
    {
        BirthDayProp = new(day, month, year);
    }

    /// <summary>
    /// Изменить ссылку на аватар
    /// </summary>
    /// <param name="avatarURL"></param>
    public void SetAvatar(string avatarURL)
    {
        AvatarUrl = new(avatarURL);
    }
    
    /// <summary>
    /// Изменить пол
    /// </summary>
    /// <param name="gender"></param>
    public void SetGender(Gender gender)
    {
        GenderProp = gender;
    }
    
    /// <summary>
    /// изменить комментарий/замечание
    /// </summary>
    /// <param name="comment"></param>
    public void SetComment(string comment)
    {
        CommentProp = new(comment);
    }

    /// <summary>
    /// Получить список опытов работы
    /// </summary>
    /// <returns></returns>
    public WorkExperience[] GetWorkExperiencesList()
    {
        return WorkExperiences;
    }

    /// <summary>
    /// Получить сущность WorkExperience
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public WorkExperience? GetWorkExperienceById(int id)
    {
        for (int i = 0; i < WorkExperiences.Length; i++)
        {
            if (WorkExperiences[i].ID == id)
            {
                return WorkExperiences[i];
            }
        }

        return null;
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
        WorkExperiences = [.. WorkExperiences, workExperience];
    }

    /// <summary>
    /// Удалить сущность WorkExperience по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteWorkExperienceById(int id)
    {
        for (int i = 0; i < WorkExperiences.Length; i++)
        {
            if (WorkExperiences[i].ID == id){
                WorkExperiences = [.. WorkExperiences[..i], .. WorkExperiences[(i + 1)..]];
                return true;
            }
        }

        return false;
    }
    
}
