using StaffPro.Person.Domain.Entities.Person;
using StaffPro.Person.Domain.Entities.PersonInfo;


namespace StaffPro.Person.Domain
{
    public class Class1
    {
        Person.Domain.Entities.Person.Person person = new(
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
}

