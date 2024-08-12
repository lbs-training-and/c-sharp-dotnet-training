using CSharpDesignPatterns.AbstractFactory.Abstraction;

namespace CSharpDesignPatterns.AbstractFactory.Models;

internal class Dog : IAnimal
{
    public string Speak()
    {
        return "Woof!";
    }
}