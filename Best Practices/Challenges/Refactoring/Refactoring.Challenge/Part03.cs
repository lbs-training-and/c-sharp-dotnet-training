using Refactoring.Challenge.Interfaces;

namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a recursive method that attempts to make a worker work.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
/// </summary>
public class Part03
{
    private readonly IWorker _worker;

    public Part03(IWorker worker)
    {
        _worker = worker;
    }
    
    public async Task<bool> Run(int maxAttempts)
    {
        if (maxAttempts > 0)
        {
            var worked = await _worker.TryWorkAsync();

            if (!worked)
            {
                worked = await Run(--maxAttempts);
            }
            else
            {
                return worked;
            }

            return worked;
        }
        else
        {
            return false;
        }
    }
}