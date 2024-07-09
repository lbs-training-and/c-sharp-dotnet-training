namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a method that checks if a number is prime.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
/// </summary>
public class Part01
{
    public bool Run(int n)
    {
        if (n <= 1) return false; for (int i = 2; i < n; i++) { if (n % i == 0) return false; }
        return true;
    }
}