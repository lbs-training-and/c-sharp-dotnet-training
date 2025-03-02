using CSharpDesignPatterns.Observer.Abstraction;

namespace CSharpDesignPatterns.Observer;

internal class OwnerObserver : IAnimalObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Owner has been notified: {message}");
    }
}
