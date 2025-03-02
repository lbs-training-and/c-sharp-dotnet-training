using CSharpDesignPatterns.Strategy.Abstraction;

namespace CSharpDesignPatterns.Strategy;

internal class FriendlyBehaviour : IAnimalBehaviour
{
    public void Interact()
    {
        Console.WriteLine("The animal is friendly and will let you pet it.");
    }
}