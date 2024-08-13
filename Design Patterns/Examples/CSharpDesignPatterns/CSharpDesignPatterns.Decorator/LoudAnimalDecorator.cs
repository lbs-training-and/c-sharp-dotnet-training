using CSharpDesignPatterns.Decorator.Abstraction;

namespace CSharpDesignPatterns.Decorator;

internal class LoudAnimalDecorator : AnimalDecorator
{
    internal LoudAnimalDecorator(IAnimal animal) : base(animal)
    {
    }

    public override void MakeSound()
    {
        Console.Write("Loudly, ");
        base.MakeSound();
    }
}