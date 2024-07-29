namespace UnitTests.Challenge
{
    /// <summary>
    /// These parts involve writing tests for parts 1-4, follow the document for more information
    /// </summary>
    public class BasicCalculator
    {
        public BasicCalculator(decimal value = 0)
        {
            Total = value;
        }
        
        public decimal Total { get; private set; }

        public decimal Add (decimal value)
        {
            return Total += value;
        }

        public decimal Subtract(decimal value)
        {
            return Total -= value;
        }

        public decimal Multiply (decimal value)
        {
            return Total *= value;
        }

        public decimal Divide (decimal value)
        {
            if (value == 0)
            {
                throw new ArithmeticException("Can't divide by 0.");
            }
            
            return Total /= value;
        }

        public decimal Reset(decimal value = 0)
        {
            return Total = value;
        }
    }
}
