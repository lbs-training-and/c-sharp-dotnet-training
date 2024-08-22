using BurgerBytes.App.Models;

namespace BurgerBytes.App.Orders;

public class OrderManager : IOrderManager
{
    private int _orderId = 1;
    
    private readonly ICollection<Order> _orders = new List<Order>();

    public IReadOnlyCollection<Order> GetAll()
    {
        var orders = _orders.ToArray();

        return orders;
    }

    public void Add(Order order)
    {
        order.Id = _orderId++;
        _orders.Add(order);
    }
}