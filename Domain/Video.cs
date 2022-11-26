using Domain.Exceptions;

namespace Domain;

/// <summary>
/// Объект хранящий данные о видео
/// </summary>
public class Video
{
    /// <summary>
    /// Приватный конструктор для EF
    /// </summary>
    private Video()
    {
        
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Id для записи в БД</param>
    /// <param name="name">Имя видео</param>
    /// <param name="path">Путь до видео в файловой системе</param>
    /// <exception cref="IdNotValidException">Ошибка при пустом идентификаторе</exception>
    /// <exception cref="NameNotValidException">Ошибка при пустом названии видео</exception>
    /// <exception cref="PathNotValidException">Ошибка при пустом пути</exception>
    /// <exception cref="PathNotExistException">Ошбка при не существующем пути к видео</exception>
    public Video(Guid id, string name, string path)
    {
        if (id == Guid.Empty) throw new IdNotValidException(id);
        Id = id;
        if (string.IsNullOrWhiteSpace(name)) throw new NameNotValidException(name);
        Name = name;
        if (string.IsNullOrWhiteSpace(path)) throw new PathNotValidException(path);
        if (File.Exists(path)) throw new PathNotExistException(path);
        Path = path;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Path { get; }
}