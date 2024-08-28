using BurgerBytes.App.Models;

namespace BurgerBytes.App.Orders;

public interface IOrderItemsProcess
{
    ICollection<OrderItem> TakeOrderItems(IReadOnlyCollection<Item> items);
}