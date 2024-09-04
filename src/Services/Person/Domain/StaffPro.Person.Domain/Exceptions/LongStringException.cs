namespace StaffPro.Person.Domain.Exceptions;

/// <summary>
/// Exception Была передана слишком длинная строка 
/// </summary>
public class LongStringException : Exception
{
    public int maxLength;
    public LongStringException(int maxLength)
    : base($"Слишком длинная строка. Максимальная длина - {maxLength}.")
    {
    }
}
