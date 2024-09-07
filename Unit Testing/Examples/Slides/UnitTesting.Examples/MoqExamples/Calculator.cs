namespace UnitTesting.Examples.MoqExamples;

public class Calculator
{
    private readonly IMathHandler _mathHandler;
    private readonly IPrinter _printer;

    public Calculator(IMathHandler mathHandler, IPrinter printer)
    {
        _mathHandler = mathHandler;
        _printer = printer;
    }
    
    public decimal Total { get; private set; }

    public decimal Add(decimal value)
    {
        Total = _mathHandler.Add(Total, value);
        _printer.Print(Total);
        return Total;
    }
}