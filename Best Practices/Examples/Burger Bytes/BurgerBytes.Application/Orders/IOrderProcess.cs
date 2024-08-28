using BurgerBytes.App.Models;

namespace BurgerBytes.App.Orders;

public interface IOrderProcess
{
    Order TakeOrder();
}