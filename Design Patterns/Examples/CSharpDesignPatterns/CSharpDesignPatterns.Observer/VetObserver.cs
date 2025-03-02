using CSharpDesignPatterns.Observer.Abstraction;

namespace CSharpDesignPatterns.Observer;

internal class VetObserver : IAnimalObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Vet has been notified: {message}");
    }
}
