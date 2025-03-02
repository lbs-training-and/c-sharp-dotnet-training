using CSharpDesignPatterns.Builder.Models;

namespace CSharpDesignPatterns.Builder;

internal class CatBuilder
{
    private readonly Cat _cat = new();

    internal CatBuilder WithName(string name)
    {
        _cat.Name = name;
        return this;
    }

    internal CatBuilder AsBreed(string breed)
    {
        _cat.Breed = breed;
        return this;
    }

    internal CatBuilder WithColor(string color)
    {
        _cat.Color = color;
        return this;
    }

    internal Cat Build()
    {
        return _cat;
    }
}