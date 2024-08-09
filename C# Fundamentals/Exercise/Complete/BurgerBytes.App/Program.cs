using BurgerBytes.App.Input;
using BurgerBytes.App.Items;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Output;

namespace BurgerBytes.App;

public class Program
{
    public static void Main(string[] args)
    {
        var menu = new Menu();
        
        var outputHandler = new ConsoleOutputHandler();
        var inputHandler = new ConsoleInputHandler(outputHandler);
        
        var navigationOptions = new INavigationOption[]
        {
            new CreateOrderNavigationOption(menu, outputHandler, inputHandler)
        };
        
        var navigator = new Navigator(navigationOptions, outputHandler, inputHandler);
        
        navigator.Navigate();
    }
}