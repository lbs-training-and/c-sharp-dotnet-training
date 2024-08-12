namespace CSharpDesignPatterns.MethodFactory.Models;

internal class Dog : Animal
{
    internal override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}