using MediatR;

namespace Application.Video.Queries.GetPathToVideo;

/// <summary>
/// Get path to video file
/// </summary>
public class GetPathToVideoQuery : IRequest<string>
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="nameOfVideo">Name of video file</param>
    public GetPathToVideoQuery(string nameOfVideo)
    {
        NameOfVideo = nameOfVideo;
    }

    /// <summary>
    /// Name of video file
    /// </summary>
    public string NameOfVideo { get; }
}