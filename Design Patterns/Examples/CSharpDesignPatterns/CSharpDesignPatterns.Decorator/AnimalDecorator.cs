using CSharpDesignPatterns.Decorator.Abstraction;

namespace CSharpDesignPatterns.Decorator;

internal abstract class AnimalDecorator : IAnimal
{
    private readonly IAnimal _animal;

    private protected AnimalDecorator(IAnimal animal)
    {
        _animal = animal;
    }
    
    public virtual void MakeSound()
    {
        _animal.MakeSound();
    }
}