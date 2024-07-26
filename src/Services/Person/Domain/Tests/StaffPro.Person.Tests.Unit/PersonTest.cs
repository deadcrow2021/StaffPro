using StaffPro.Person.Domain.Entities.Person;
using Xunit;

namespace StaffPro.Person.Tests.Unit;
public class PersonTest
{
    public Person person { get; set; }

    public PersonTest()
    {
        person = new(
            1,
            "fisrt",
            "last",
            "patr",
            "test@mail.ru",
            "+79991234567",
            15,
            10,
            2024,
            "/data/image.png",
            Gender.Male,
            "Comment 123"
        );
    }

    [Fact]
    public void Test1()
    {
        Assert.Equal(1, 1);
    }
}