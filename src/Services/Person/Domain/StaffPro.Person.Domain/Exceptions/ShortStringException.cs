namespace StaffPro.Person.Domain.Exceptions;

public class ShortStringException : Exception
{
    public int minLength;
    public ShortStringException(int minLength)
    : base($"Слишком короткая строка. Минимальная длина - {minLength}.")
    {
        this.minLength = minLength;
    }
}
