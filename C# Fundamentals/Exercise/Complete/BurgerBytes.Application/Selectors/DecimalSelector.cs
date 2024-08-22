using BurgerBytes.App.Input;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Selectors;

public class DecimalSelector : IDecimalSelector
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;

    public DecimalSelector(IInputHandler inputHandler, IOutputHandler outputHandler)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
    }

    public decimal Select(string message, decimal min, decimal max, int scale)
    {
        while (true)
        {
            var value = _inputHandler.RequestDecimal(message);

            if (value < min || value > max)
            {
                _outputHandler.Write($"The value must be either or between {min} and {max}.");
                continue;
            }

            if (Math.Round(value, scale) != value)
            {
                _outputHandler.Write($"The value must have {scale} decimal places or less.");
                continue;
            }

            return value;
        }
    }
}