namespace CSharpDesignPatterns.MethodFactory.Models;

internal class Cat : Animal
{
    internal override void Speak()
    {
        Console.WriteLine("Meow!");
    }
}