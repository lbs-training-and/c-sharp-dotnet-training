namespace BurgerBytes.App.Navigation;

public interface INavigationOption
{
    string DisplayName { get; }

    void Enter();
}