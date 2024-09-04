namespace StaffPro.Person.Domain.Exceptions;

/// <summary>
/// Exception Была передана слишком короткая строка 
/// </summary>
public class ShortStringException : Exception
{
    public int minLength;
    public ShortStringException(int minLength)
    : base($"Слишком короткая строка. Минимальная длина - {minLength}.")
    {
    }
}
