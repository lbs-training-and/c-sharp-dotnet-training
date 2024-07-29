namespace UnitTests.Challenge.Interfaces;

public interface IJob
{
    Task<bool> PerformAsync(int attempt);
}