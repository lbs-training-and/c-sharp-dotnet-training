namespace BurgerBytes.App.Navigation;

public interface INavigationOptionSelector
{
    INavigationOption? Select(IReadOnlyCollection<INavigationOption> navigationOptions);
}