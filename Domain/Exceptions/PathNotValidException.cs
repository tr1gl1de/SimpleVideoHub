namespace Domain.Exceptions;

public class PathNotValidException : ArgumentException
{
    public PathNotValidException(string path) : base($"{nameof(path)} can not be null or empty.")
    {
    }
}