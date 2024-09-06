using BurgerBytes.App.Selectors;

namespace BurgerBytes.App.Navigation;

public class Navigator : INavigator
{
    private readonly INavigationOptionSelector _navigationOptionSelector;
    private readonly IReadOnlyCollection<INavigationOption> _navigationOptions;

    public Navigator(
        INavigationOptionSelector navigationOptionSelector,
        IEnumerable<INavigationOption> navigationOptions)
    {
        _navigationOptionSelector = navigationOptionSelector;
        _navigationOptions = navigationOptions.ToArray();
    }

    public async Task NavigateAsync()
    {
        while (true)
        {
            var navigationOption = _navigationOptionSelector.Select(_navigationOptions);

            if (navigationOption == null)
            {
                return;
            }

            await navigationOption.EnterAsync();
        }
    }
}