namespace BurgerBytes.App.Currency;

public class CurrencyProvider : ICurrencyProvider
{
    public string Symbol => "$";
    public int Scale => 2;
}