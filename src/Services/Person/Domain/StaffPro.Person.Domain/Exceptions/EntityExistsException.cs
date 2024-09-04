namespace StaffPro.Person.Domain.Exceptions;

/// <summary>
/// Exception Сущность с переданным идентефикатором уже существует
/// </summary>
public class EntityExistsException : Exception
{
    public EntityExistsException(string entityName, int id)
    : base($"Сущность {entityName} с идентификатором {id} уже существует.")
    {
    }
}
