using Refactoring.Challenge.Models;

namespace Refactoring.Challenge;

/// <summary>
/// This part involves refactoring a method that returns paged orders.
/// The Run method should:
///     * Be refactored to use a simpler solution.
///     * Not break the existing test.
/// </summary>
public class Part09
{
    public IReadOnlyCollection<Order> Run(IReadOnlyCollection<Order> orders, OrderStatus orderStatus, int page, int pageSize)
    {
        var filteredOrders = new List<Order>();

        foreach (var order in orders)
        {
            if (order.Status == orderStatus)
            {
                filteredOrders.Add(order);
            }
        }
        
        filteredOrders.Sort((l, r) => DateTime.Compare(l.Created, r.Created));

        var pageStart = page * pageSize - pageSize;

        if (pageStart > filteredOrders.Count)
        {
            return new List<Order>();
        }

        if (pageStart + pageSize > filteredOrders.Count)
        {
            pageSize = filteredOrders.Count - pageStart;
        }
        
        filteredOrders = filteredOrders.Slice(pageStart, pageSize);

        return filteredOrders;
    }
}