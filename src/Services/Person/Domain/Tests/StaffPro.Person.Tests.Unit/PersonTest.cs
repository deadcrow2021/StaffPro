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
        TestPerson = new(
                1,
                "first",
                "last",
                "patr",
                "test@mail.ru",
                "+79991234567",
                15,
                10,
                2000,
                "/data/image.png",
                eGender.Male,
                "Comment 123"
            );
    }

    [Test]
    public void ChangeFirstName_FirstNameEqualsToChangedFirstName_True()
    {
        Assert.That(TestPerson.FullName.FirstName, Is.EqualTo("first"));

        TestPerson.FullName.ChangeFirstName("changedName");
        Assert.That(TestPerson.FullName.FirstName, Is.EqualTo("changedName"));

        TestPerson.FullName.ChangeFirstName("testName");
        Assert.That(TestPerson.FullName.FirstName, Is.EqualTo("testName"));
    }

    [Test]
    public void ChangeLastName_LastNameEqualsToChangedLastName_True()
    {
        Assert.That(TestPerson.FullName.LastName, Is.EqualTo("last"));

        TestPerson.FullName.ChangeLastName("changedName");
        Assert.That(TestPerson.FullName.LastName, Is.EqualTo("changedName"));

        TestPerson.FullName.ChangeLastName("testName");
        Assert.That(TestPerson.FullName.LastName, Is.EqualTo("testName"));
    }

    [Test]
    public void ChangePatronymic_PatronymicEqualsToChangedPatronymic_True()
    {
        Assert.That(TestPerson.FullName.Patronymic, Is.EqualTo("patr"));

        TestPerson.FullName.ChangePatronymic("changedName");
        Assert.That(TestPerson.FullName.Patronymic, Is.EqualTo("changedName"));

        TestPerson.FullName.ChangePatronymic("testName");
        Assert.That(TestPerson.FullName.Patronymic, Is.EqualTo("testName"));
    }

    [Test]
    public void ChangeFullName_FullNameEqualsToChangedFullName_True()
    {
        Assert.That(TestPerson.FullName.FirstName, Is.EqualTo("first"));
        Assert.That(TestPerson.FullName.LastName, Is.EqualTo("last"));
        Assert.That(TestPerson.FullName.Patronymic, Is.EqualTo("patr"));

        TestPerson.SetFullName("FirstName", "LastName", "Patronymic");

        Assert.That(TestPerson.FullName.FirstName, Is.EqualTo("FirstName"));
        Assert.That(TestPerson.FullName.LastName, Is.EqualTo("LastName"));
        Assert.That(TestPerson.FullName.Patronymic, Is.EqualTo("Patronymic"));
    }

    [Test]
    public void ChangeFirstName_FirstNameEqualsToChangedFirstName_ThrowsError()
    {
        Assert.Throws<ShortStringException>(() => TestPerson.FullName.ChangeFirstName(""));
        Assert.Throws<LongStringException>(() => TestPerson.FullName.ChangeFirstName(longString));
        Assert.Throws<ArgumentException>(() => TestPerson.FullName.ChangeFirstName("test123"));
        Assert.Throws<ArgumentException>(() => TestPerson.FullName.ChangeFirstName("test_name"));
    }

    [Test]
    public void ChangeLastName_FullLastEqualsToChangedLastName_ThrowsError()
    {
        Assert.Throws<ShortStringException>(() => TestPerson.FullName.ChangeLastName(""));
        Assert.Throws<LongStringException>(() => TestPerson.FullName.ChangeLastName(longString));
        Assert.Throws<ArgumentException>(() => TestPerson.FullName.ChangeLastName("test123"));
        Assert.Throws<ArgumentException>(() => TestPerson.FullName.ChangeLastName("test_name"));
    }

    [Test]
    public void ChangePatronymic_PatronymicEqualsToChangedPatronymic_ThrowsError()
    {
        Assert.Throws<ShortStringException>(() => TestPerson.FullName.ChangePatronymic(""));
        Assert.Throws<LongStringException>(() => TestPerson.FullName.ChangePatronymic(longString));
        Assert.Throws<ArgumentException>(() => TestPerson.FullName.ChangePatronymic("test123"));
        Assert.Throws<ArgumentException>(() => TestPerson.FullName.ChangePatronymic("test_name"));
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
        DateTime birthDate = new(2000, 10, 15);
        Assert.That(TestPerson.BirthDay, Is.EqualTo(birthDate));

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
        TestPerson = new(
            1,
            "first",
            "last",
            "patr",
            "test@mail.ru",
            "+79991234567",
            15,
            10,
            2000,
            "/data/image.png",
            eGender.Male,
            "Comment 123"
        );

        TestPerson.AddWorkExperience(
            1, "jun programmer", "zxc comp", "test_desc1",
            new DateTime(2020, 1, 10),
            new DateTime(2022, 6, 12)
        );

        TestPerson.AddWorkExperience(
            2, "mid programmer", "asd comp", "test_desc2",
            new DateTime(2022, 7, 10),
            new DateTime(2023, 8, 12)
        );
    }

    [Test]
    public void AddWorkExperience_GetNewWorkExperienceById_True()
    {
        TestPerson.AddWorkExperience(
            3, "senior programmer", "ctsg", "test_desc3",
            new DateTime(2023, 9, 10),
            new DateTime(2024, 10, 12)
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
        Assert.Throws<LongStringException>(() => personExp.SetAddress(city: longString));
        Assert.Throws<LongStringException>(() => personExp.SetAddress(country: longString));
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





public class TestPerson : Faker<StaffPro.Person.Domain.Entities.Person>
{
    public TestPerson(TestFullName _TestFullName, TestEmail _TestEmail, TestPhoneNumber _TestPhoneNumber, TestAvatar _TestAvatar)
    {
        int id = 1;
        
        UseSeed(123)
        .RuleFor(p => p.Id, _ => id++)
        .RuleFor(p => p.FullName, _ => _TestFullName.Generate(1).First())
        .RuleFor(p => p.Email, _ => _TestEmail.Generate(1).First())
        .RuleFor(p => p.PhoneNumber, _ => _TestPhoneNumber.Generate(1).First())
        .RuleFor(p => p.BirthDay, f => f.Date.Between(DateTime.Parse("1/1/1970"), DateTime.Parse("1/1/2000")))
        .RuleFor(p => p.Avatar, _ => _TestAvatar.Generate(1).First())
        .RuleFor(p => p.Gender, f => f.PickRandom<eGender>())
        .RuleFor(p => p.Comment, f => f.Name.JobDescriptor());
    }
}

public class TestFullName : Faker<FullName>
{
    public TestFullName()
    {
        UseSeed(123)
        .RuleFor(c => c.FirstName, f => f.Name.FirstName())
        .RuleFor(c => c.LastName, f => f.Name.LastName())
        .RuleFor(c => c.Patronymic, f => f.Name.FirstName());
    }
}

public class TestEmail : Faker<Email>
{
    public TestEmail()
    {
        UseSeed(123)
        .RuleFor(c => c.EmailAddress, f => f.Internet.Email());
    }
}

public class TestPhoneNumber : Faker<PhoneNumber>
{
    public TestPhoneNumber()
    {
        UseSeed(123)
        .RuleFor(c => c.PhoneNumberStr, f => f.Phone.PhoneNumber("ru"));
    }
}

public class TestAvatar : Faker<Avatar>
{
    public TestAvatar()
    {
        UseSeed(123)
        .RuleFor(c => c.AvatarURL, f => f.Internet.Avatar());
    }
}

