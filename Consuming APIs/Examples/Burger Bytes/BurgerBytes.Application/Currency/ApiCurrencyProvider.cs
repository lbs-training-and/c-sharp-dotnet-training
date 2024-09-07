using BurgerBytes.App.Api;

namespace BurgerBytes.App.Currency;

public class ApiCurrencyProvider : ICurrencyProvider
{
    private readonly IBurgerBytesApi _burgerBytesApi;

    public ApiCurrencyProvider(IBurgerBytesApi burgerBytesApi)
    {
        _burgerBytesApi = burgerBytesApi;
    }
    
    public async Task<Currency> GetAsync()
    {
        var currencyDto = await _burgerBytesApi.GetCurrencyAsync();

        return new Currency
        {
            Symbol = currencyDto.Symbol,
            Scale = currencyDto.Scale
        };
    }
}