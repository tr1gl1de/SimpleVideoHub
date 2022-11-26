namespace Domain.Exceptions;

public class IdNotValidException : ArgumentException
{
    public IdNotValidException(Guid id) : base($"{nameof(id)} can not be empty or null.")
    {
    }
}