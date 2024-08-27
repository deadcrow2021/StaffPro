namespace StaffPro.Person.Domain.Exceptions;

public class LongStringException : Exception
{
    public int maxLength;
    public LongStringException(int maxLength)
    : base($"Слишком длинная строка. Максимальная длина - {maxLength}.")
    {
        this.maxLength = maxLength;
    }
}
