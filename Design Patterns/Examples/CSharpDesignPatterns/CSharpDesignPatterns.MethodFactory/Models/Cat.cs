namespace CSharpDesignPatterns.MethodFactory.Models;

public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Meow!");
    }
}