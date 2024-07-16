namespace UnitTests.Challenge
{
    /// <summary>
    /// These parts involve writing tests for parts 1-4, follow the document for more information
    /// </summary>
    public class Part01_04
    {
        private int _total;

        public Part01_04(int startValue)
        {
            _total = startValue;
        }

        public int Add (int value)
        {
            return _total + value;
        }

        public int Subtract(int value)
        {
            return _total - value;
        }

        public int Multiply (int value)
        {
            return _total * value;
        }

        public int Devide (int value)
        {
            return _total / value;
        }

        public int GetTotal()
        {
            return (_total);
        }
    }
}
