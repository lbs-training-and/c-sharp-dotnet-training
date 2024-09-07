using FluentAssertions;
using UnitTesting.Examples.FluentAssertionsExamples;

namespace UnitTesting.Examples.Tests.FluentAssertionsExamples;

[TestFixture]
public class MusicPlayerTests
{
    [Test]
    public void CanPlayTrackById()
    {
        // Arrange

        const int trackId = 5;
        var musicPlayer = new MusicPlayer();

        // Act

        var track = musicPlayer.Play(trackId);

        // Assert

        track.Should().NotBe(null)
            .And.Be(musicPlayer.CurrentTrack)
            .And.Match<Track>(t => t.Id == trackId);
    }

    [Test]
    public void PlayHandlesInvalidTrackId()
    {
        // Arrange

        const int trackId = -1;
        var musicPlayer = new MusicPlayer();

        // Act

        var action = () => musicPlayer.Play(trackId);

        // Assert

        action.Should().Throw<ArgumentException>()
            .WithParameterName("trackId")
            .WithMessage("Must be greater than or equal to 0.*");
    }
}