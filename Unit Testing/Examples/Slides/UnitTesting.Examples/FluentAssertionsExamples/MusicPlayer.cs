namespace UnitTesting.Examples.FluentAssertionsExamples;

public class MusicPlayer
{
    public Track? CurrentTrack { get; private set; }
    
    public Track Play(int trackId)
    {
        if (trackId < 0)
        {
            throw new ArgumentException("Must be greater than or equal to 0.", nameof(trackId));
        }
        
        return CurrentTrack = new Track { Id = trackId };
    }
}