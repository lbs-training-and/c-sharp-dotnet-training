using FluentAssertions;
using Moq;
using UnitTesting.Examples.MoqExamples;

namespace UnitTesting.Examples.Tests.MoqExamples;


[TestFixture]
public class MusicPlayerTests
{
    [Test]
    public async Task CanPlaySelectedTrack()
    {
        // Arrange

        var mockRepository = new MockRepository(MockBehavior.Loose);
        
        var library = mockRepository.Create<ILibrary>();
        var playback = mockRepository.Create<IPlayback>();

        const int trackId = 5;
        var expectedTrack = new Track();

        library
            .Setup(l => l.GetTrackAsync(trackId))
            .ReturnsAsync(expectedTrack);
        
        playback.Setup(pb => pb.Play(expectedTrack, It.IsAny<TimeSpan>()));
        
        var musicPlayer = new MusicPlayer(library.Object, playback.Object);

        // Act

        var track = await musicPlayer.PlayAsync(trackId);

        // Assert

        track.Should().Be(expectedTrack).And.Be(musicPlayer.CurrentTrack);
        
        mockRepository.VerifyAll();
        mockRepository.VerifyNoOtherCalls();
    }
}

// [TestFixture]
// public class MusicPlayerTests
// {
//     [Test]
//     public async Task CanPlaySelectedTrack()
//     {
//         // Arrange
//
//         var library = new Mock<ILibrary>();
//         var playback = new Mock<IPlayback>();
//
//         const int trackId = 5;
//         var expectedTrack = new Track();
//
//         library
//             .Setup(l => l.GetTrackAsync(trackId))
//             .ReturnsAsync(expectedTrack);
//         
//         var musicPlayer = new MusicPlayer(library.Object, playback.Object);
//
//         // Act
//
//         var track = await musicPlayer.PlayAsync(trackId);
//
//         // Assert
//
//         track.Should().Be(expectedTrack).And.Be(musicPlayer.CurrentTrack);
//         
//         playback
//             .Verify(pb => pb.Play(expectedTrack, It.IsAny<TimeSpan>()), Times.Once);
//         
//         library.VerifyAll();
//         library.VerifyNoOtherCalls();
//     }
// }

// [TestFixture]
// public class MusicPlayerTests
// {
//     [Test]
//     public async Task CanPlaySelectedTrack()
//     {
//         // Arrange
//
//         var library = new Mock<ILibrary>();
//         var playback = new Mock<IPlayback>();
//
//         const int trackId = 5;
//         var expectedTrack = new Track();
//
//         library
//             .Setup(l => l.GetTrackAsync(trackId))
//             .ReturnsAsync(expectedTrack);
//
//         playback.Setup(pb => pb.Play(expectedTrack, It.IsAny<TimeSpan>()));
//         
//         var musicPlayer = new MusicPlayer(library.Object, playback.Object);
//
//         // Act
//
//         var track = await musicPlayer.PlayAsync(trackId);
//
//         // Assert
//
//         track.Should().Be(expectedTrack).And.Be(musicPlayer.CurrentTrack);
//     }
// }