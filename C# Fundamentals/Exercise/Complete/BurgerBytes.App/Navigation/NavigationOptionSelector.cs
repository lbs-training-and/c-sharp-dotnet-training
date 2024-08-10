using BurgerBytes.App.Input;
using BurgerBytes.App.Output;
using BurgerBytes.App.Selectors;

namespace BurgerBytes.App.Navigation;

public class NavigationOptionSelector : INavigationOptionSelector
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;
    private readonly IIntSelector _intSelector;

    public NavigationOptionSelector(IInputHandler inputHandler, IOutputHandler outputHandler, IIntSelector intSelector)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
        _intSelector = intSelector;
    }

    public INavigationOption? Select(IReadOnlyCollection<INavigationOption> navigationOptions)
    {
        for (var i = 0; i < navigationOptions.Count; i++)
        {
            var option = navigationOptions.ElementAt(i);

            _outputHandler.Write($"[{i + 1}] | {option.DisplayName}");
        }

        _outputHandler.Write("[0] | Exit");

        var optionId = _intSelector.Select("Select option", 0, navigationOptions.Count);
        
        var selectedOption = navigationOptions.ElementAt(optionId - 1);

        return selectedOption;
    }
}