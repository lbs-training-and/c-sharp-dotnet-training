using CSharpDesignPatterns.Observer.Abstraction;

namespace CSharpDesignPatterns.Observer.Models;

internal class Cat
{
    private readonly List<IAnimalObserver> _observers = [];

    public void AddObserver(IAnimalObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IAnimalObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Meow()
    {
        // This ordering is arbitrary...
        // Sometimes you may wish to perform your notification
        // actions prior to the rest of the logic -
        // sometimes it might even be in between!
        Console.WriteLine("The cat says: Meow!");
        NotifyObservers("The cat just meowed.");
    }

    private void NotifyObservers(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}