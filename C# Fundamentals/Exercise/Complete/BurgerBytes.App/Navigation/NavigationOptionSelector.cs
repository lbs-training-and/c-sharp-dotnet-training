using BurgerBytes.App.Input;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Navigation;

public class NavigationOptionSelector : INavigationOptionSelector
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;

    public NavigationOptionSelector(IInputHandler inputHandler, IOutputHandler outputHandler)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
    }

    public INavigationOption? Select(IReadOnlyCollection<INavigationOption> navigationOptions)
    {
        for (var i = 0; i < navigationOptions.Count; i++)
        {
            var option = navigationOptions.ElementAt(i);

            _outputHandler.Write($"[{i + 1}] | {option.DisplayName}");
        }

        _outputHandler.Write("[0] | Exit");

        var optionId = _inputHandler.RequestInt("Select option.");
        
        while (true)
        {
            if (optionId == 0)
            {
                return null;
            }

            if (optionId < 0 || optionId > navigationOptions.Count)
            {
                continue;
            }

            var option = navigationOptions.ElementAt(optionId - 1);

            return option;
        }
    }
}