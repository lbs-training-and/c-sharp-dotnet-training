using BurgerBytes.App.Navigation;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Selectors;

public class NavigationOptionSelector : INavigationOptionSelector
{
    private readonly IOutputHandler _outputHandler;
    private readonly IIntSelector _intSelector;

    public NavigationOptionSelector(IOutputHandler outputHandler, IIntSelector intSelector)
    {
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

        if (optionId == 0)
        {
            return null;
        }
        
        var selectedOption = navigationOptions.ElementAt(optionId - 1);

        return selectedOption;
    }
}