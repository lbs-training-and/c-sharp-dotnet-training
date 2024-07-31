using UnitTests.Challenge.Interfaces;

namespace UnitTests.Challenge;

public class StandardCalculator
{
    private readonly IMathHandler _mathHandler;
    private readonly IScreen _screen;

    public StandardCalculator(IMathHandler mathHandler, IScreen screen, decimal total = 0)
    {
        _mathHandler = mathHandler;
        _screen = screen;
        Total = total;
    }
    
    public decimal Total { get; private set; }

    public decimal Add (decimal value)
    {
        Total = _mathHandler.Add(Total, value);
        _screen.Display(Total);
        return Total;
    }

    public decimal Subtract(decimal value)
    {
        Total = _mathHandler.Subtract(Total, value);
        _screen.Display(Total);
        return Total;
    }

    public decimal Multiply (decimal value)
    {
        Total = _mathHandler.Multiply(Total, value);
        _screen.Display(Total);
        return Total;
    }

    public decimal Divide (decimal value)
    {
        Total = _mathHandler.Divide(Total, value);
        _screen.Display(Total);
        return Total;
    }
    
    public decimal Reset(decimal value = 0)
    {
        Total = value;
        _screen.Display(Total);
        return Total;
    }
}