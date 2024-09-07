using Microsoft.Extensions.Logging;

namespace BurgerBytes.App.Output;

public class ConsoleOutputHandler : IOutputHandler
{
    private readonly ILogger<ConsoleOutputHandler> _logger;

    public ConsoleOutputHandler(ILogger<ConsoleOutputHandler> logger)
    {
        _logger = logger;
    }
    
    public void Write(string message)
    {
        Console.WriteLine(message);
        _logger.LogTrace("Output handled: Message: {Message}", message);
    }
}