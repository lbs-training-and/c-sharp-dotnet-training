using CSharpDesignPatterns.Strategy.Abstraction;

namespace CSharpDesignPatterns.Strategy.Models;

internal class Cat : Animal
{
    internal Cat(IAnimalBehaviour behavior) : base(behavior)
    {
    }

    internal override void DisplayAnimalType()
    {
        Console.WriteLine("This is a cat.");
    }
}