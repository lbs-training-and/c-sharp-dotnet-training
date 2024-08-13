using CSharpDesignPatterns.Facade.Models;

namespace CSharpDesignPatterns.Facade.Services;

internal class WalkingService
{
    internal void Walk(Dog dog)
    {
        Console.WriteLine($"{dog.Name} is going for a walk.");
    }
}