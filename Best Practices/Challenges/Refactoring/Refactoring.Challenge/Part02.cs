namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a method that finds the maximum value in a list.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
///     * Should not use Linq
/// </summary>
public class Part02
{
    public int Run(List<int> nums)
    {
        int m = 0; foreach (var n in nums) { if (n > m) m = n; }
        return m;
    }
}
