namespace UnitTesting.Examples.MoqExamples;

public interface ILibrary
{
    Task<Track> GetTrackAsync(int id);
}