using BurgerBytes.App.Api.Models;

namespace BurgerBytes.App.Api;

public interface IBurgerBytesApi
{
    Task<CurrencyDto> GetCurrencyAsync();
}