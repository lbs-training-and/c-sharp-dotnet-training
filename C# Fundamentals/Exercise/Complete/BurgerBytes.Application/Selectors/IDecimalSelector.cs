namespace BurgerBytes.App.Selectors;

public interface IDecimalSelector
{
    decimal Select(string message, decimal min, decimal max, int scale);
}