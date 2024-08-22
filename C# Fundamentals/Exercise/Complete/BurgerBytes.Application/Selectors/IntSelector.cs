using BurgerBytes.App.Input;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Selectors;

public class IntSelector : IIntSelector
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;

    public IntSelector(IInputHandler inputHandler, IOutputHandler outputHandler)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
    }
    
    public int Select(string message, int min, int max)
    {
        while (true)
        {
            var value = _inputHandler.RequestInt(message);

            if (value < min || value > max)
            {
                _outputHandler.Write($"The value must be either or between {min} and {max}.");
                continue;
            }

            return value;
        }
    }
}