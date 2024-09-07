namespace UnitTests.Challenge.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not Found Exception.")
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
