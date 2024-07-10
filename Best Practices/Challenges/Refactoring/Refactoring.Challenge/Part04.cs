namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a method that calculates the sum of numbers.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
/// </summary>
public class Part04
{
    public double Run(IReadOnlyCollection<int> numbers)
    {
        var total = 0;
        var count = 0;

        foreach (var number in numbers)
        {
            total += number;
            count++;
        }

        var average = total / count;

        return average;
    }
}