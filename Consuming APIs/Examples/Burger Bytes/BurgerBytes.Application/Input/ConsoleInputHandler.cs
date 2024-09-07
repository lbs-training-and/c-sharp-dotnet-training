using BurgerBytes.App.Output;
using Microsoft.Extensions.Logging;

namespace BurgerBytes.App.Input;

public class ConsoleInputHandler : IInputHandler
{
    private readonly IOutputHandler _outputHandler;
    private readonly ILogger<ConsoleInputHandler> _logger;

    public ConsoleInputHandler(IOutputHandler outputHandler, ILogger<ConsoleInputHandler> logger)
    {
        _outputHandler = outputHandler;
        _logger = logger;
    }

    public string? Request(string message)
    {
        _outputHandler.Write(message);
        
        var input = Console.ReadLine();

        _logger.LogTrace("Input handled. Value: {Value}", input);
        
        return input;
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
            
            _outputHandler.Write("Enter a whole number.");
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
            
            _outputHandler.Write("Enter a number.");
        }
    }
}