using BurgerBytes.App.Models;

namespace BurgerBytes.App.Selectors;

public interface IOrderSelector
{
    Order Select(IReadOnlyCollection<Order> orders);
}