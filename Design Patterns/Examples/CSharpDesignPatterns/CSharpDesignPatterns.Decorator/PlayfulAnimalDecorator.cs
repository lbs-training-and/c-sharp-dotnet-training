using CSharpDesignPatterns.Decorator.Abstraction;

namespace CSharpDesignPatterns.Decorator;

internal class PlayfulAnimalDecorator : AnimalDecorator
{
    internal PlayfulAnimalDecorator(IAnimal animal) : base(animal)
    {
    }

    public override void MakeSound()
    {
        Console.Write("Playfully, ");
        base.MakeSound();
    }
}