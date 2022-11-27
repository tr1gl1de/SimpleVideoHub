namespace Domain.Exceptions;

public class PathNotExistException : ArgumentException
{
    public PathNotExistException(string path) : base($"{nameof(path)} not exist.")
    {
    }
}