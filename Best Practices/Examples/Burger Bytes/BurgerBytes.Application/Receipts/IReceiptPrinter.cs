using BurgerBytes.App.Models;

namespace BurgerBytes.App.Receipts;

public interface IReceiptPrinter
{
    Task PrintAsync(Order order);
}