using CSharpDesignPatterns.Strategy.Abstraction;

namespace CSharpDesignPatterns.Strategy;

internal class AggressiveBehaviour : IAnimalBehaviour
{
    public void Interact()
    {
        Console.WriteLine("The animal growls and shows its teeth.");
    }
}