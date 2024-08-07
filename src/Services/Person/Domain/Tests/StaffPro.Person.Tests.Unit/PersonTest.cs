using StaffPro.Person.Domain.Entities.PersonInfo;
using StaffPro.Person.Domain.Entities.Person;
using StaffPro.Person.Domain;
using Xunit;
using StaffPro.Person.Domain.Entities.WorkExperienceEntity;

namespace StaffPro.Person.Tests.Unit;

public class PersonTest
{
    public StaffPro.Person.Domain.Entities.Person.Person TestPerson { get; set; }

    public PersonTest()
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
            Gender.Male,
            "Comment 123"
        );
    }


    [Fact]
    public void ChangePersonFirstNameTest()
    {
        Assert.Equal("first", TestPerson.Fio.FirstName);

        TestPerson.Fio.ChangeFirstName("changedName");
        Assert.Equal("changedName", TestPerson.Fio.FirstName);

        TestPerson.Fio.ChangeFirstName("testName");
        Assert.Equal("testName", TestPerson.Fio.FirstName);
    }

    [Fact]
    public void ChangePersonLastNameTest()
    {
        Assert.Equal("last", TestPerson.Fio.LastName);

        TestPerson.Fio.ChangeLastName("changedName");
        Assert.Equal("changedName", TestPerson.Fio.LastName);

        TestPerson.Fio.ChangeLastName("testName");
        Assert.Equal("testName", TestPerson.Fio.LastName);
    }

    [Fact]
    public void ChangePersonPatronymicTest()
    {
        Assert.Equal("patr", TestPerson.Fio.Patronymic);

        TestPerson.Fio.ChangePatronymic("changedName");
        Assert.Equal("changedName", TestPerson.Fio.Patronymic);

        TestPerson.Fio.ChangePatronymic("testName");
        Assert.Equal("testName", TestPerson.Fio.Patronymic);
    }

    [Fact]
    public void ChangePersonFIOTest()
    {
        Assert.Equal("first", TestPerson.Fio.FirstName);
        Assert.Equal("last", TestPerson.Fio.LastName);
        Assert.Equal("patr", TestPerson.Fio.Patronymic);

        TestPerson.SetFIO("FirstName", "LastName", "Patronymic");

        Assert.Equal("FirstName", TestPerson.Fio.FirstName);
        Assert.Equal("LastName", TestPerson.Fio.LastName);
        Assert.Equal("Patronymic", TestPerson.Fio.Patronymic);
    }

    [Fact]
    public void FailedChangePersonFirstNameTest()
    {
        string longName = String.Concat(Enumerable.Repeat("test", 100));

        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeFirstName(""));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeFirstName(longName));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeFirstName("test123"));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeFirstName("test_name"));
    }

    [Fact]
    public void FailedChangePersonLastNameTest()
    {
        string longName = String.Concat(Enumerable.Repeat("test", 100));

        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeLastName(""));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeLastName(longName));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeLastName("test123"));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangeLastName("test_name"));
    }

    [Fact]
    public void FailedChangePersonPatronymicTest()
    {
        string longName = String.Concat(Enumerable.Repeat("test", 100));

        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangePatronymic(""));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangePatronymic(longName));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangePatronymic("test123"));
        Assert.Throws<ArgumentException>(() => TestPerson.Fio.ChangePatronymic("test_name"));
    }

    [Theory]
    [InlineData("test@mail.ru")]
    [InlineData("test_changed@mail.com")]
    [InlineData("testChanged@mail.com")]
    public void ChangePersonEmailTest(string email)
    {
        TestPerson.SetEmail(email);
        Assert.Equal(email, TestPerson.EmailProp.EmailAddress);
    }

    [Theory]
    [InlineData("")]
    [InlineData("test")]
    [InlineData("test@")]
    [InlineData("@mail.ru")]
    [InlineData("test123@mail")]
    [InlineData("test123@.ru")]
    public void FailedChangePersonEmailTest(string email)
    {

        Assert.Throws<ArgumentException>(() => TestPerson.SetEmail(email));
    }

    [Theory]
    [InlineData("+79991234567")]
    [InlineData("89991234567")]
    public void ChangePersonPhoneNumberTest(string phoneNumber)
    {
        TestPerson.SetPhoneNumber(phoneNumber);
        Assert.Equal(phoneNumber, TestPerson.PhoneNumberProp.PhoneNumberStr);
    }

    [Theory]
    [InlineData("")]
    [InlineData("09991234567")]
    [InlineData("19991234567")]
    [InlineData("9991234567")]
    [InlineData("+7999")]
    [InlineData("+7asd9991234567123123")]
    [InlineData("+7999123")]
    public void FailedChangePersonPhoneNumberTest(string phoneNumber)
    {
        Assert.Throws<ArgumentException>(() => TestPerson.SetPhoneNumber(phoneNumber));
    }

    [Fact]
    public void ChangePersonBirthDateTest()
    {
        DateTime birthDate = new(2000, 10, 15);
        Assert.Equal(birthDate, TestPerson.BirthDayProp.BirthDate);

        DateTime birthDate1 = new(2001, 11, 16);
        TestPerson.SetBirthDate(16, 11, 2001);
        Assert.Equal(birthDate1, TestPerson.BirthDayProp.BirthDate);
    }

    [Fact]
    public void ChangePersonGenderTest()
    {
        TestPerson.SetGender(Gender.Female);
        Assert.Equal(Gender.Female, TestPerson.GenderProp);

        TestPerson.SetGender(Gender.Male);
        Assert.Equal(Gender.Male, TestPerson.GenderProp);
    }

    [Theory]
    [InlineData("")]
    [InlineData("Test Comment")]
    public void ChangePersonCommentTest(string comment)
    {
        TestPerson.SetComment(comment);
        Assert.Equal(comment, TestPerson.CommentProp.CommentStr);
    }

    [Theory]
    [InlineData("/doc/image.png")]
    [InlineData("/doc/img/image.jpg")]
    [InlineData("C:\\Documents\\image.jpg")]
    [InlineData("C:/Documents/image.jpg")]
    [InlineData("C:Documents/image.jpg")]
    public void ChangePersonAvatarTest(string AvatarUrl)
    {
        TestPerson.SetAvatar(AvatarUrl);
        Assert.Equal(AvatarUrl, TestPerson.AvatarUrl.AvatarURL);
    }
}


public class PersonWorkExperienceTest
{
    public StaffPro.Person.Domain.Entities.Person.Person TestPerson { get; set; }

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
            Gender.Male,
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

    [Fact]
    public void AddWorkExperienceTest()
    {
        TestPerson.AddWorkExperience(
            3, "senior programmer", "ctsg", "test_desc3",
            new DateTime(2023, 9, 10),
            new DateTime(2024, 10, 12)
        );

        WorkExperience? newExp = TestPerson.GetWorkExperienceById(3);
        Assert.NotNull(newExp);
        Assert.Equal(3, TestPerson.WorkExperiences.Length);
    }

    [Fact]
    public void DeleteWorkExperienceTest()
    {
        bool deleteStatus = TestPerson.DeleteWorkExperienceById(2);
        WorkExperience? expObj = TestPerson.GetWorkExperienceById(2);

        Assert.True(deleteStatus);
        Assert.Null(expObj);
        Assert.Single(TestPerson.WorkExperiences);
    }

    [Fact]
    public void ChangeWorkExperiencePositionTest()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetPosition("changed position");
        Assert.Equal("changed position", personExp.Position);
    }

    [Fact]
    public void FailedChangeWorkExperiencePositionTest()
    {
        string longStr = String.Concat(Enumerable.Repeat("test", 100));

        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        Assert.Throws<ArgumentException>(() => personExp.SetPosition(longStr));
    }

    [Fact]
    public void ChangeWorkExperienceOrganizationTest()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetOrganization("changed_org");
        Assert.Equal("changed_org", personExp.Organization);
    }

    [Fact]
    public void FailedChangeWorkExperienceOrganizationTest()
    {
        string longStr = String.Concat(Enumerable.Repeat("test", 100));

        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        Assert.Throws<ArgumentException>(() => personExp.SetOrganization(longStr));
    }

    [Fact]
    public void ChangeWorkExperienceAddressTest()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetAddress("test city", "test country");
        Assert.Equal("test city", personExp.JobAddress.City);
        Assert.Equal("test country", personExp.JobAddress.Country);
    }

    [Fact]
    public void FailedChangeWorkExperienceAddressTest()
    {
        string longStr = String.Concat(Enumerable.Repeat("test", 100));

        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        Assert.Throws<ArgumentException>(() => personExp.SetAddress(city: longStr));
        Assert.Throws<ArgumentException>(() => personExp.SetAddress(country: longStr));
    }

    [Fact]
    public void ChangeWorkExperienceDescriptionTest()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);
        personExp.SetDescription("changed_descr");
        Assert.Equal("changed_descr", personExp.Description);
    }

    [Fact]
    public void ChangeWorkExperienceEmploymentAndFiringDatesTest()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);

        personExp.SetFiringDate(new DateTime(2023, 12, 20));
        personExp.SetEmploymentDate(new DateTime(2023, 10, 11));

        Assert.Equal(new DateTime(2023, 12, 20), personExp.FiringDate);
        Assert.Equal(new DateTime(2023, 10, 11), personExp.EmploymentDate);
    }

    [Fact]
    public void FailedChangeWorkExperienceEmploymentAndFiringDatesTest()
    {
        WorkExperience? personExp = TestPerson.GetWorkExperienceById(1);

        personExp.SetFiringDate(new DateTime(2023, 12, 20));
        Assert.Throws<ArgumentException>(() => personExp.SetEmploymentDate(new DateTime(2024, 10, 11)));

        personExp.SetEmploymentDate(new DateTime(2023, 10, 11));
        Assert.Throws<ArgumentException>(() => personExp.SetFiringDate(new DateTime(2023, 1, 1)));
    }
}