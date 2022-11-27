namespace Domain.Exceptions;

public class NameNotValidException : ArgumentException
{
    public NameNotValidException(string name) : base($"{nameof(name)} can not be empty or null.")
    {
    }
}