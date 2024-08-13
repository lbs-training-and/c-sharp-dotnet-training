using CSharpDesignPatterns.Facade.Models;

namespace CSharpDesignPatterns.Facade.Services;

internal class GroomingService
{
    internal void Groom(Dog dog)
    {
        Console.WriteLine($"{dog.Name} is getting a haircut.");
    }
}