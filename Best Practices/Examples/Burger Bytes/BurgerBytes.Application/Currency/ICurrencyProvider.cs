namespace BurgerBytes.App.Currency;

public interface ICurrencyProvider
{
    Task<Currency> GetAsync();
}