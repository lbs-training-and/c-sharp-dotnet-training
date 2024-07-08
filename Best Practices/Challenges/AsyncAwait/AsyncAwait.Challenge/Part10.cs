using AsyncAwait.Challenge.Interfaces;

namespace AsyncAwait.Challenge;

/// <summary>
/// This part involves concurrently running multiple async methods and returning the result from which completed first.
/// The Run method should:
///     * Make each racer race concurrently.
///     * Return the result of the racer that finished first.
///     * HINT - A method already exists to do this.
/// </summary>
public class Part10
{
    private readonly IEnumerable<IRacer> _racers;

    public Part10(IEnumerable<IRacer> racers)
    {
        _racers = racers;
    }

    public object Run()
    {
        throw new NotImplementedException();
    }
}