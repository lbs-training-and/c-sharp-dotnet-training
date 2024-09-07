namespace UnitTesting.Examples.MoqExamples;

public class MusicPlayer
{
    private readonly ILibrary _library;
    private readonly IPlayback _playback;

    public MusicPlayer(ILibrary library, IPlayback playback)
    {
        _library = library;
        _playback = playback;
    }
    
    public Track? CurrentTrack { get; private set; }
    
    public async Task<Track> PlayAsync(int trackId)
    {
        var nextTrack = await _library.GetTrackAsync(trackId);
        
        _playback.Play(nextTrack, TimeSpan.Zero);

        return CurrentTrack = nextTrack;
    }
}