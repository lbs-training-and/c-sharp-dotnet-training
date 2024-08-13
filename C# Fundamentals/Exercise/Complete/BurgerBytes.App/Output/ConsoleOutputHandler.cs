namespace BurgerBytes.App.Output;

public class ConsoleOutputHandler : IOutputHandler
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}