namespace BurgerBytes.App.Currency;

public interface ICurrencyProvider
{
    string Symbol { get; }
    int Scale { get; }
}