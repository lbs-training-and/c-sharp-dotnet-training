using CSharpDesignPatterns.AbstractFactory.Abstraction;

namespace CSharpDesignPatterns.AbstractFactory.Models;

internal class Cat : IAnimal
{
    public string Speak()
    {
        return "Meow!";
    }
}