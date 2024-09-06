using BurgerBytes.App.Models;

namespace BurgerBytes.App.Orders;

public interface IOrderProcess
{
    Task<Order> TakeOrderAsync();
}