namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a palindrome check.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
///     * NOTE - The reverse of this is sometimes asked in interviews, what is the fastest way to check if a string is a palindrome.
/// </summary>
public class Part02
{
    public bool Run(string text)
    {
        var length = text.Length;
        var charactersToCheck = length / 2;
        
        for (var i = 0; i < charactersToCheck; i++)
        {
            if (text[i] != text[length - i - 1])
            {
                return false;
            }
        }
        
        return true;
    }
}