namespace Refactoring.Challenge.Interfaces;

public interface IWorker
{
    Task<bool> TryWorkAsync();
    Task Sleep();
}