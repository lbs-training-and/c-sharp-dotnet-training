using CSharpDesignPatterns.Builder.Models;

namespace CSharpDesignPatterns.Builder;

/*
 * This acts as the 'Director' within this pattern
 *
 * It could have been called CatDirector but that does
 * not align with what it actually does.
 *
 * TIP: Always favour logical/descriptive naming conventions
 */
internal class CatCreator
{
    private readonly CatBuilder _builder;

    internal CatCreator(CatBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    internal Cat BuildHouseCat()
    {
        return _builder
            .AsBreed("Domestic Shorthair")
            .WithColor("Gray")
            .Build();
    }

    internal Cat BuildShowCat()
    {
        return _builder
            .AsBreed("Persian")
            .WithColor("White")
            .Build();
    }
}