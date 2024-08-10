using BurgerBytes.App.Input;
using BurgerBytes.App.Navigation;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Orders;

public class ViewOrdersNavigationOptions : INavigationOption
{
    private readonly IInputHandler _inputHandler;
    private readonly IOutputHandler _outputHandler;
    private readonly IOrderManager _orderManager;
    private readonly IOrderViewer _orderViewer;

    public ViewOrdersNavigationOptions(
        IInputHandler inputHandler,
        IOutputHandler outputHandler,
        IOrderManager orderManager, 
        IOrderViewer orderViewer)
    {
        _inputHandler = inputHandler;
        _outputHandler = outputHandler;
        _orderManager = orderManager;
        _orderViewer = orderViewer;
    }

    
    public string DisplayName { get; } = "View Orders";
    
    public void Enter()
    {
        var orders = _orderManager.GetAll();

        if (orders.Count == 0)
        {
            _outputHandler.Write("There are no orders.");
            return;
        }
        
        do
        {
            _orderViewer.View(orders);

        } while (_inputHandler.RequestBool("Do you want to view another order?"));
    }
}