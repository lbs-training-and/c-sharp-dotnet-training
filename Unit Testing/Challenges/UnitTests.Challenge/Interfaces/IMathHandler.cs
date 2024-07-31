namespace UnitTests.Challenge.Interfaces;

public interface IMathHandler
{
    decimal Add(decimal left, decimal right);
    
    decimal Multiply(decimal left, decimal right);
    
    decimal Subtract(decimal left, decimal right);
    
    decimal Divide(decimal left, decimal right);
}