using Domain.Entities;
using Domain.Exceptions;

namespace Domain.UnitTest;

public class VideoTest : IDisposable
{
    private readonly Guid _defaultId = Guid.NewGuid();
    private readonly string _defaultVideoName = "Little cats";
    private readonly string _defaultPathToVideoFile; 

    public VideoTest()
    {
        _defaultPathToVideoFile = Path.Combine(Environment.CurrentDirectory,"someFOledreForTes", "kitty.webm");
        CreateFile(_defaultPathToVideoFile);
    }

    public void Dispose()
    {
        DeleteFile(_defaultPathToVideoFile);
    }

    private static void CreateFile(string pathToFile)
    {
        Directory.CreateDirectory(pathToFile.Remove(pathToFile.LastIndexOf('\\')));
        File.Create(pathToFile).Dispose();
    }

    private static void DeleteFile(string pathToFile)
    {
        File.Delete(pathToFile);
    }
    

    [Theory]
    [InlineData("F5EED3BF-8870-47DF-9EC1-2835F014BBCF")]
    [InlineData("DFC88271-8801-47AA-BD0A-3B03A5E0D058")]
    public void Constructor_Id_IdValue(Guid testId)
    {
        // Act
        var actualVideo = new Video(testId, _defaultVideoName, _defaultPathToVideoFile);
        
        // Assert
        Assert.Equal(testId, actualVideo.Id);
    }

    [Theory]
    [InlineData("Kitties")]
    [InlineData("x")]
    [InlineData("xioЪ╙")]
    public void Constructor_VideoName_NameValue(string testName)
    {
        // Act
        var actualVideo = new Video(_defaultId, testName, _defaultPathToVideoFile);
        
        // Assert
        Assert.Equal(testName, actualVideo.Name);
    }

    [Fact]
    public void Constructor_PathToVideo_PathToVideoValue()
    {
        // Arrange
        var pathToFileTest = Path.Join(Environment.CurrentDirectory, "dogs.mp4");
        CreateFile(pathToFileTest);
        
        // Act
        var actualVideo = new Video(_defaultId, _defaultVideoName, pathToFileTest);
        DeleteFile(pathToFileTest);
        
        // Assert
        Assert.Equal(pathToFileTest, actualVideo.Path);
    }

    [Fact]
    public void Constructor_AllParams_AllParamsValid()
    {
        // Arrange
        var pathToFileTest = Path.Join(Environment.CurrentDirectory, "any.avi");
        CreateFile(pathToFileTest);
        var videoId = Guid.NewGuid();
        var videoName = "some shit";

        // Act
        var actualVideo = new Video(videoId, videoName, pathToFileTest);
        DeleteFile(pathToFileTest);

        // Assert
        Assert.Equal(videoId, actualVideo.Id);
        Assert.Equal(videoName, actualVideo.Name);
        Assert.Equal(pathToFileTest, actualVideo.Path);
    }

    [Fact]
    public void Constructor_NotValidId_ThrowNotValidIdException()
    {
        // Arrange
        var videoId = Guid.Empty;

        // Act
        var a = () => new Video(videoId, _defaultVideoName, _defaultPathToVideoFile);

        // Assert
        Assert.Throws<IdNotValidException>(a);  
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("      ")]
    public void Constructor_NotValidVideoName_ThrowNotValidNameException(string testName)
    {
        // Act
        var a = () => new Video(_defaultId, testName, _defaultPathToVideoFile);
        // Assert
        Assert.Throws<NameNotValidException>(a);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("   ")]
    public void Constructor_NotValidPath_ThrowPathNotValidException(string testPathToFile)
    {
        // Act
        var a = () => new Video(_defaultId, _defaultVideoName, testPathToFile);
        // Assert
        Assert.Throws<PathNotValidException>(a);
    }

    [Theory]
    [InlineData(@"somefoleder\asdkji\ad.p4")]
    [InlineData("ok")]
    [InlineData("c")]
    public void Constructor_NotExistsPath_ThrowPathNotExistsException(string testPathToFile)
    {
        // Act
        var a = () => new Video(_defaultId, _defaultVideoName, testPathToFile);
        // Assert
        Assert.Throws<PathNotExistException>(a);
    }

    [Fact]
    public void PrivateConstructor_ShouldCreateInstanceForEF()
    {
        // Act
        var actualVideo = Activator.CreateInstance(typeof(Video), true);
        
        // Assert
        Assert.NotNull(actualVideo);
    }
}