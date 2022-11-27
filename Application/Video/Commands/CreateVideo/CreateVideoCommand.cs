using Application.Video.Dtos;
using MediatR;

namespace Application.Video.Commands.CreateVideo;

/// <summary>
/// Add video to server
/// </summary>
public class CreateVideoCommand : IRequest<string>
{
    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="videoForCreateDto">Dto for create video</param>
    /// <param name="videoFileStream">Video file stream</param>
    public CreateVideoCommand(VideoForCreateDto videoForCreateDto, Stream videoFileStream)
    {
        VideoForCreateDto = videoForCreateDto;
        VideoFileStream = videoFileStream;
    }

    /// <summary>
    /// Dto for create video
    /// </summary>
    public VideoForCreateDto VideoForCreateDto { get; }
    
    /// <summary>
    /// Video file stream
    /// </summary>
    public Stream VideoFileStream { get; }
}