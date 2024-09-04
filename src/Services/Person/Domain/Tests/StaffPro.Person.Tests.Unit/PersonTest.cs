using StaffPro.Person.Domain.ValueObjects;
using StaffPro.Person.Domain.Exceptions;
using StaffPro.Person.Domain.Entities;
using StaffPro.Person.Domain.Enums;
using Bogus;

namespace StaffPro.Person.Tests.Unit;


public class PersonTests
{
    private StaffPro.Person.Domain.Entities.Person TestPerson { get; set; }
    string longString = String.Concat(Enumerable.Repeat("test", 100));

    [SetUp]
    public void Setup()
    {
        TestPerson = FakeDataGenerator.CreatePerson().Generate();
    }

    [Test]
    public void SetFullName_FullNameAttrsEqualsToChangedAttrs_True()
    {
        TestPerson.SetFullName("changedFirstName", "changedLastName", "changedPatronymic");
        Assert.That(TestPerson.FullName.FirstName, Is.EqualTo("changedFirstName"));
        Assert.That(TestPerson.FullName.LastName, Is.EqualTo("changedLastName"));
        Assert.That(TestPerson.FullName.Patronymic, Is.EqualTo("changedPatronymic"));
    }

    [Test]
    public void SetFullName_SetInvalidFirstName_ThrowsError()
    {
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("", "changedLastName", "changedPatronymic"));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName(null, "changedLastName", "changedPatronymic"));
        Assert.Throws<LongStringException>(() => TestPerson.SetFullName(longString, "changedLastName", "changedPatronymic"));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("test123", "changedLastName", "changedPatronymic"));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("test_name", "changedLastName", "changedPatronymic"));
    }

    [Test]
    public void SetFullName_SetInvalidLastName_ThrowsError()
    {
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", "", "changedPatronymic"));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", null, "changedPatronymic"));
        Assert.Throws<LongStringException>(() => TestPerson.SetFullName("changedFirstName", longString, "changedPatronymic"));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", "test123", "changedPatronymic"));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", "test_name", "changedPatronymic"));
    }

    [Test]
    public void SetFullName_SetInvalidPatronymic_ThrowsError()
    {
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", "changedLastName", ""));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", "changedLastName", null));
        Assert.Throws<LongStringException>(() => TestPerson.SetFullName("changedFirstName", "changedLastName", longString));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", "changedLastName", "test123"));
        Assert.Throws<ArgumentException>(() => TestPerson.SetFullName("changedFirstName", "changedLastName", "test_name"));
    }


    [TestCase("test@mail.ru")]
    [TestCase("test_changed@mail.com")]
    [TestCase("testChanged@mail.com")]
    public void SetEmail_EmailEqualsToChangedEmail_True(string email)
    {
        TestPerson.SetEmail(email);
        Assert.That(TestPerson.Email.EmailAddress, Is.EqualTo(email));
    }

    [TestCase("")]
    [TestCase("test")]
    [TestCase("test@")]
    [TestCase("@mail.ru")]
    [TestCase("test123@mail")]
    [TestCase("test123@.ru")]
    public void SetEmail_EmailEqualsToChangedEmail_ThrowsError(string email)
    {
        Assert.Throws<ArgumentException>(() => TestPerson.SetEmail(email));
    }

    [TestCase("+79991234567")]
    [TestCase("89991234567")]
    public void SetPhoneNumber_PhoneNumberEqualsToChangedPhoneNumber_True(string phoneNumber)
    {
        TestPerson.SetPhoneNumber(phoneNumber);
        Assert.That(TestPerson.PhoneNumber.PhoneNumberStr, Is.EqualTo(phoneNumber));
    }

    [TestCase("")]
    [TestCase("09991234567")]
    [TestCase("19991234567")]
    [TestCase("9991234567")]
    [TestCase("+7999")]
    [TestCase("+7asd9991234567123123")]
    [TestCase("+7999123")]
    public void SetPhoneNumber_PhoneNumberEqualsToChangedPhoneNumber_ThrowsError(string phoneNumber)
    {
        Assert.Throws<ArgumentException>(() => TestPerson.SetPhoneNumber(phoneNumber));
    }

    [Test]
    public void SetBirthDate_BirthDateEqualsToChangedBirthDate_True()
    {
        DateTime birthDate1 = new(2001, 11, 16);
        TestPerson.BirthDay = new DateTime(2001, 11, 16);
        Assert.That(TestPerson.BirthDay, Is.EqualTo(birthDate1));
    }

    [Test]
    public void SetGender_GenderEqualsToChangedGender_True()
    {
        TestPerson.SetGender(eGender.Female);
        Assert.That(TestPerson.Gender, Is.EqualTo(eGender.Female));

        TestPerson.SetGender(eGender.Male);
        Assert.That(TestPerson.Gender, Is.EqualTo(eGender.Male));
    }

    [TestCase("")]
    [TestCase("Test Comment")]
    public void SetComment_CommentEqualsToChangedComment_True(string comment)
    {
        TestPerson.Comment = comment;
        Assert.That(TestPerson.Comment, Is.EqualTo(comment));
    }

    [TestCase("/doc/image.png")]
    [TestCase("/doc/img/image.jpg")]
    [TestCase("C:\\Documents\\image.jpg")]
    [TestCase("C:/Documents/image.jpg")]
    [TestCase("C:Documents/image.jpg")]
    public void SetAvatar_AvatarEqualsToChangedAvatar_True(string avatarUrl)
    {
        TestPerson.SetAvatar(avatarUrl);
        Assert.That(TestPerson.Avatar.AvatarURL, Is.EqualTo(avatarUrl));
    }
}



public class PersonWorkExperienceTest
{
    private StaffPro.Person.Domain.Entities.Person TestPerson { get; set; }
    string longString = String.Concat(Enumerable.Repeat("test", 100));

    public PersonWorkExperienceTest()
    {
        TestPerson = FakeDataGenerator.CreatePerson().Generate();

        TestPerson.AddWorkExperience(
            1, "jun programmer", "zxc comp", "test_desc1",
            new DateTime(2020, 1, 10),
            new DateTime(2022, 6, 12),
            string.Empty, string.Empty
        );

        TestPerson.AddWorkExperience(
            2, "mid programmer", "asd comp", "test_desc2",
            new DateTime(2022, 7, 10),
            new DateTime(2023, 8, 12),
            string.Empty, string.Empty
        );
    }

    [Test]
    public void AddWorkExperience_GetNewWorkExperienceById_True()
    {
        TestPerson.AddWorkExperience(
            3, "senior programmer", "ctsg", "test_desc3",
            new DateTime(2023, 9, 10),
            new DateTime(2024, 10, 12),
            string.Empty, string.Empty
        );

        WorkExperience? newExp = TestPerson.GetWorkExperienceById(3);
        Assert.NotNull(newExp);
        Assert.That(TestPerson.WorkExperiences.Count, Is.EqualTo(3));
    }

    [Test]
    public void DeleteWorkExperienceById_CantGetDeletedWorkExperience_Null()
    {
        bool deleteStatus = TestPerson.DeleteWorkExperienceById(2);
        WorkExperience? expObj = TestPerson.GetWorkExperienceById(2);

        Assert.True(deleteStatus);
        Assert.Null(expObj);
    }

    [Test]
    public void SetPosition_PositionEqualsToChangedPosition_True()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetPosition("changed position");
    }

    [Test]
    public void SetPosition_PositionEqualsToChangedPosition_ThrowsException()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        Assert.Throws<LongStringException>(() => personExp.SetPosition(longString));
    }

    [Test]
    public void SetOrganization_OrganizationEqualsToChangedOrganization_True()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetOrganization("changed_org");
        Assert.That(personExp.Organization, Is.EqualTo("changed_org"));
    }

    [Test]
    public void SetOrganization_OrganizationEqualsToChangedOrganization_ThrowsException()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        Assert.Throws<LongStringException>(() => personExp.SetOrganization(longString));
    }

    [Test]
    public void SetAddress_AddressEqualsToChangedAddress_True()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetAddress("test city", "test country");
        Assert.That(personExp.Address.City, Is.EqualTo("test city"));
        Assert.That(personExp.Address.Country, Is.EqualTo("test country"));
    }

    [Test]
    public void SetAddress_AddressEqualsToChangedAddress_ThrowsException()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        Assert.Throws<LongStringException>(() => personExp.SetAddress(string.Empty, longString));
        Assert.Throws<LongStringException>(() => personExp.SetAddress(longString, string.Empty));
    }

    [Test]
    public void SetDescription_DescriptionEqualsToChangedDescription_True()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetDescription("changed_descr");
        Assert.That(personExp.Description, Is.EqualTo("changed_descr"));
    }

    [Test]
    public void SetFiringDate_SetEmploymentDate_DescriptionEqualsToChangedDescription_True()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);

        personExp.SetFiringDate(new DateTime(2023, 12, 20));
        personExp.SetEmploymentDate(new DateTime(2023, 10, 11));

        Assert.That(personExp.FiringDate, Is.EqualTo(new DateTime(2023, 12, 20)));
        Assert.That(personExp.EmploymentDate, Is.EqualTo(new DateTime(2023, 10, 11)));
    }

    [Test]
    public void SetFiringDate_SetEmploymentDate_DescriptionEqualsToChangedDescription_ThrowsException()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);

        personExp.SetFiringDate(new DateTime(2023, 12, 20));
        Assert.Throws<ArgumentException>(() => personExp.SetEmploymentDate(new DateTime(2024, 10, 11)));

        personExp.SetEmploymentDate(new DateTime(2023, 10, 11));
        Assert.Throws<ArgumentException>(() => personExp.SetFiringDate(new DateTime(2023, 1, 1)));
    }
}

/// <summary>
/// Класс для генерации рандомных данных для 
/// </summary>
public static class FakeDataGenerator
{
    public static Faker<StaffPro.Person.Domain.Entities.Person> CreatePerson()
    {
        return new Faker<StaffPro.Person.Domain.Entities.Person>()
            .CustomInstantiator(f => new StaffPro.Person.Domain.Entities.Person(
                1,
                f.Name.FirstName(),
                f.Name.LastName(),
                f.Name.LastName(),
                f.Internet.Email(),
                "+79991234567",
                f.Random.Int(1, 28),
                f.Random.Int(1, 12),
                f.Random.Int(1970, 2000),
                "/data/image.png",
                eGender.Male,
                f.Name.JobDescriptor()));
    }
}
