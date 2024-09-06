namespace BurgerBytes.App.Currency;

public class GbpCurrencyProvider : ICurrencyProvider
{
    private Currency _currency = new()
    {
        Symbol = "£",
        Scale = 2
    };


    public Task<Currency> GetAsync() => Task.FromResult(_currency);
}