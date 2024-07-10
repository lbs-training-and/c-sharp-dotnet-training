using Refactoring.Challenge.Interfaces;
using Refactoring.Challenge.Models;

namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a slow method.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
/// </summary>
public class Part08
{
    private readonly IEnumerable<IWorker> _workers;

    public Part08(IEnumerable<IWorker> workers)
    {
        _workers = workers;
    }

    public async Task Run()
    {
        foreach (var worker in _workers)
        {
            await worker.Sleep();
        }
    }
}