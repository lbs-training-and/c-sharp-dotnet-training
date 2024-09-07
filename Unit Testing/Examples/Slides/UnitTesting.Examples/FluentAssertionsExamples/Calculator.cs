namespace UnitTesting.Examples.FluentAssertionsExamples;

public class Calculator
{
    public Calculator(decimal seed)
    {
        Total = seed;
    }
    
    public decimal Total { get; private set; }

    public decimal Divide(decimal value)
    {
        if (value == 0)
        {
            throw new ArithmeticException("Can't divide by 0.");
        }
        
        return Total /= value;
    }
}