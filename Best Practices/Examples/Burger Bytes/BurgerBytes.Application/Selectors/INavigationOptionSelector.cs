using BurgerBytes.App.Navigation;

namespace BurgerBytes.App.Selectors;

public interface INavigationOptionSelector
{
    INavigationOption? Select(IReadOnlyCollection<INavigationOption> navigationOptions);
}