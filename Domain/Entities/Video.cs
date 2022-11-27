using Domain.Exceptions;

namespace Domain.Entities;

/// <summary>
/// Entity of video
/// </summary>
public class Video
{
    /// <summary>
    /// Private ctor for EF
    /// </summary>
    private Video()
    {
        
    }
    
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <param name="name">Name of video on page</param>
    /// <param name="path">Full path with name to video file on storage</param>
    /// <exception cref="IdNotValidException">Exception if id empty</exception>
    /// <exception cref="NameNotValidException">Exception if name null or empty</exception>
    /// <exception cref="PathNotValidException">Exception if path to file null or empty</exception>
    /// <exception cref="PathNotExistException">Exception if file not exists</exception>
    public Video(Guid id, string name, string path)
    {
        if (id == Guid.Empty) throw new IdNotValidException(id);
        if (string.IsNullOrWhiteSpace(name)) throw new NameNotValidException(name);
        if (string.IsNullOrWhiteSpace(path)) throw new PathNotValidException(path);
        if (!File.Exists(path)) throw new PathNotExistException(path);

        Id = id;
        Name = name;
        Path = path;
    }

    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Name of video
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Full path with name to video file storage
    /// </summary>
    public string Path { get; }
}