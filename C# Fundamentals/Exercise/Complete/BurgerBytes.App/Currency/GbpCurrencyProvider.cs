namespace BurgerBytes.App.Currency;

public class CurrencyProvider : ICurrencyProvider
{
    public string Symbol { get; } = "£";
    public int Scale { get; } = 2;
}