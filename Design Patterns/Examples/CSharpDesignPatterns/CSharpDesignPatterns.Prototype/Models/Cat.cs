namespace CSharpDesignPatterns.Prototype.Models;

internal class Cat : Animal
{
    private readonly string _species;

    internal Cat (string species)
    {
        _species = species;
    }

    internal override Animal Clone()
    {
        return new Cat(_species);
    }

    internal string GetSpecies()
    {
        return _species;
    }
}