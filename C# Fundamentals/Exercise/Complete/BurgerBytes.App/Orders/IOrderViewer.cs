using BurgerBytes.App.Models;

namespace BurgerBytes.App.Orders;

public interface IOrderViewer
{
    void View(IReadOnlyCollection<Order> orders);
}