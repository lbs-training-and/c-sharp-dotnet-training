namespace BurgerBytes.App.Api.Models;

public class CurrencyDto
{
    public required string Symbol { get; init; }
    public int Scale { get; init; }
}