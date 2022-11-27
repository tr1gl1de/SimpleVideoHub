using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Video.Commands.CreateVideo;

/// <summary>
/// Handler of request for create video
/// </summary>
public class CreateVideoCommandHandler : IRequestHandler<CreateVideoCommand, string>
{
    private readonly IVideoDbContext _videoDbContext;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="videoDbContext">Db context of video</param>
    public CreateVideoCommandHandler(IVideoDbContext videoDbContext)
    {
        _videoDbContext = videoDbContext;
    }

    /// <summary>
    /// Handler
    /// </summary>
    /// <param name="request">Request with dto and file stream</param>
    /// <param name="cancellationToken">Token for cancellation</param>
    /// <returns>Video name of created video</returns>
    /// <exception cref="EntityIsExistsException">Thrown if video is exists</exception>
    public async Task<string> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        var existsVideo = await _videoDbContext.VideoDbSet.FindAsync(cancellationToken);
        
        var videoEntity = new Domain.Entities.Video(
            Guid.NewGuid(), 
            request.VideoForCreateDto.Name,
            request.VideoForCreateDto.Path);
        
        if (existsVideo is null)
        {
            throw new EntityIsExistsException(nameof(Video), request.VideoForCreateDto.Name);
        }

        await using var fileStream = File.Create(request.VideoForCreateDto.Path);
        await request.VideoFileStream.CopyToAsync(fileStream, cancellationToken);

        await _videoDbContext.VideoDbSet.AddAsync(videoEntity, cancellationToken);

        return request.VideoForCreateDto.Name;
    }
}