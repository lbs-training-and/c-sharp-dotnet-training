using BurgerBytes.App.Items;
using BurgerBytes.App.Models;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Navigation;

public class CreateOrderNavigationOption : INavigationOption
{
    private readonly IMenu _menu;
    private readonly IOutputHandler _outputHandler;
    private readonly IInputHandler _inputHandler;

    public CreateOrderNavigationOption(IMenu menu, IOutputHandler outputHandler, IInputHandler inputHandler)
    {
        _menu = menu;
        _outputHandler = outputHandler;
        _inputHandler = inputHandler;
    }

    public string DisplayName => "Create Order";

    public void Enter()
    {
        var items = _menu.GetItems();

        DisplayMenu(items);
    }

    private void DisplayMenu(IReadOnlyCollection<Item> items)
    {
        for (var i = 0; i < items.Count; i++)
        {
            var item = items.ElementAt(i);

            _outputHandler.Write($"[{i + 1}] | {item.Name}");
        }

        _outputHandler.Write("[0] | Exit");
    }
}