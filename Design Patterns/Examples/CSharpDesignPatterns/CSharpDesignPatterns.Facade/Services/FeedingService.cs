using CSharpDesignPatterns.Facade.Models;

namespace CSharpDesignPatterns.Facade.Services;

internal class FeedingService
{
    internal void Feed(Dog dog)
    {
        Console.WriteLine($"{dog.Name} is being fed.");
    }
}