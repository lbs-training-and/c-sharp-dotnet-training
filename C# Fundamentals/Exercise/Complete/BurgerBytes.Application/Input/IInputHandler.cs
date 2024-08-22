namespace BurgerBytes.App.Input;

public interface IInputHandler
{
    string? Request(string message);
    int RequestInt(string message);
    bool RequestBool(string message);
    decimal RequestDecimal(string message);
}