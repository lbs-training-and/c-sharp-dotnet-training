namespace BurgerBytes.App.Selectors;

public interface IIntSelector
{
    int Select(string message, int min, int max);
}