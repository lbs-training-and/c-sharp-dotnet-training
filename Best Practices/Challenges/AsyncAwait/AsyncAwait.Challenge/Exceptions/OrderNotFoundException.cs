namespace AsyncAwait.Challenge.Exceptions;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException(int id)
    {
        Id = id;
    }
    
    public int Id { get; }
}