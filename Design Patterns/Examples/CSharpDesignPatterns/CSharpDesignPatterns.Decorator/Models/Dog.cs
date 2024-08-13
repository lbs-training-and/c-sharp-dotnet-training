using CSharpDesignPatterns.Decorator.Abstraction;

namespace CSharpDesignPatterns.Decorator.Models;

internal class Dog : IAnimal
{
    public void MakeSound()
    {
        Console.WriteLine("The dog says: Woof!");
    }
}