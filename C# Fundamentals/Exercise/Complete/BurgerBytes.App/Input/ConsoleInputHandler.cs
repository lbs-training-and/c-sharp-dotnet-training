using BurgerBytes.App.Output;

namespace BurgerBytes.App.Input;

public class ConsoleInputHandler : IInputHandler
{
    private readonly IOutputHandler _outputHandler;

    public ConsoleInputHandler(IOutputHandler outputHandler)
    {
        _outputHandler = outputHandler;
    }
    
    public string? Request(string message)
    {
        _outputHandler.Write(message);
        return Console.ReadLine();
    }
}