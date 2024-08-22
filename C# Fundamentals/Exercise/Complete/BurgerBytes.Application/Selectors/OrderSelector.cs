using BurgerBytes.App.Models;
using BurgerBytes.App.Output;

namespace BurgerBytes.App.Selectors;

public class OrderSelector : IOrderSelector
{
    private readonly IOutputHandler _outputHandler;
    private readonly IIntSelector _intSelector;

    public OrderSelector(IOutputHandler outputHandler, IIntSelector intSelector)
    {
        _outputHandler = outputHandler;
        _intSelector = intSelector;
    }
    
    public Order Select(IReadOnlyCollection<Order> orders)
    {
        for (var i = 0; i < orders.Count; i++)
        {
            var order = orders.ElementAt(i);
            
            _outputHandler.Write($"[{i + 1}] | Order Id: {order.Id} | Table Number: {order.TableNumber} | Staff Id: {order.StaffId}");
        }

        var optionId = _intSelector.Select("Select order", 1, orders.Count);

        var selectedOrder = orders.ElementAt(optionId - 1);

        return selectedOrder;
    }
}