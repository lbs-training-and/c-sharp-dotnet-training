namespace CSharpDesignPatterns.MethodFactory.Models;

public class Dog : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Woof!");
    }
}