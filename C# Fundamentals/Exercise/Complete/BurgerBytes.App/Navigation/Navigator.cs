using BurgerBytes.App.Output;

namespace BurgerBytes.App.Navigation;

public class Navigator : INavigator
{
    private readonly IReadOnlyCollection<INavigationOption> _navigationOptions;
    private readonly IOutputHandler _outputHandler;
    private readonly IInputHandler _inputHandler;

    public Navigator(
        IReadOnlyCollection<INavigationOption> navigationOptions,
        IOutputHandler outputHandler,
        IInputHandler inputHandler)
    {
        _navigationOptions = navigationOptions;
        _outputHandler = outputHandler;
        _inputHandler = inputHandler;
    }

    public void Navigate()
    {
        while (true)
        {
            DisplayOptions();

            while (true)
            {
                var optionId = SelectOption();

                if (optionId == 0)
                {
                    return;
                }

                var option = _navigationOptions.ElementAtOrDefault(optionId - 1);

                if (option == null)
                {
                    continue;
                }
                
                option.Enter();
                break;
            }
        }
    }

    private void DisplayOptions()
    {
        for (var i = 0; i < _navigationOptions.Count; i++)
        {
            var option = _navigationOptions.ElementAt(i);

            _outputHandler.Write($"[{i + 1}] | {option.DisplayName}");
        }

        _outputHandler.Write("[0] | Exit");
    }

    private int SelectOption()
    {
        while (true)
        {
            var input = _inputHandler.Request("Select option.");

            if (int.TryParse(input, out var optionId))
            {
                return optionId;
            }
        }
    }
}