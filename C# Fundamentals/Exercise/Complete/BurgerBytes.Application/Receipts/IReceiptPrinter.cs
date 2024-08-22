using BurgerBytes.App.Models;

namespace BurgerBytes.App.Receipts;

public interface IReceiptPrinter
{
    void Print(Order order);
}