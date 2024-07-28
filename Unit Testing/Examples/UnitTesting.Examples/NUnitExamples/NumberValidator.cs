namespace UnitTesting.Examples.NUnitExamples;

public class NumberValidator
{
    public bool IsValid(string number) => decimal.TryParse(number, out _);
}