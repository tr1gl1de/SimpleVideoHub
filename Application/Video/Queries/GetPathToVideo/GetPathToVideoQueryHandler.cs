using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Video.Queries.GetPathToVideo;

/// <summary>
/// Handler of request
/// </summary>
public class GetPathToVideoQueryHandler : IRequestHandler<GetPathToVideoQuery, string>
{
    private readonly IVideoDbContext _videoDbContext;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="videoDbContext">Db context of video</param>
    public GetPathToVideoQueryHandler(IVideoDbContext videoDbContext)
    {
        _videoDbContext = videoDbContext;
    }

    /// <summary>
    /// Handler
    /// </summary>
    /// <param name="request">Request with args</param>
    /// <param name="cancellationToken">Token for cancel of operation</param>
    /// <returns>Path of video file</returns>
    public async Task<string> Handle(GetPathToVideoQuery request, CancellationToken cancellationToken)
    {
        var video = await _videoDbContext.VideoDbSet.FindAsync(cancellationToken);
        if (video is null)
        {
            throw new NotFoundException(nameof(Video), request.NameOfVideo);
        }

        return video.Path;
    }
}