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

    public int RequestInt(string message)
    {
        while (true)
        {
            var input = Request(message);

            if (int.TryParse(input, out var value))
            {
                return value;
            }
            
            _outputHandler.Write("Enter a valid whole number.");
        }
    }

    public bool RequestBool(string message)
    {
        while (true)
        {
            var input = Request($"{message} (Y/N)");

            if (bool.TryParse(input, out var value))
            {
                return value;
            }

            if (string.Equals(input, "y", StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            
            if (string.Equals(input, "n", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            
            _outputHandler.Write("Enter Y or N.");
        }
    }

    public decimal RequestDecimal(string message)
    {
        while (true)
        {
            var input = Request(message);

            if (decimal.TryParse(input, out var value))
            {
                return value;
            }
            
            _outputHandler.Write("Enter a valid whole number.");
        }
    }
}