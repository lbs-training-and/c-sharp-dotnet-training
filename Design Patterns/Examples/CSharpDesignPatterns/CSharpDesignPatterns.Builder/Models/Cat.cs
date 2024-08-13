namespace CSharpDesignPatterns.Builder.Models;

internal class Cat
{
    internal string? Name { get; set; }
    internal string? Breed { get; set; }
    internal string? Color { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Breed: {Breed}, Color: {Color}";
    }
}