namespace Application.Common.Exceptions;

public class EntityIsExistsException : Exception
{
    public EntityIsExistsException(string name, string key)
        : base($"Entity \"{name}\" ({key}) is exists.")
    {
    }
}