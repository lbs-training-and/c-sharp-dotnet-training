using CSharpDesignPatterns.Builder;

/* ----------------------------------------------*/
/* -- Classic Builder Pattern (no 'Director') -- */
/* ----------------------------------------------*/

// Create new builder
var builder = new CatBuilder();

// Use it to build out the details of the cat
var cat = builder.WithName("Mr. Meow")
                 .AsBreed("Tabby")
                 .WithColor("Ginger")
                 // Finalize with the Build method to return
                 // the new Cat object with all your settings.
                 .Build();

Console.WriteLine(cat.ToString()); // Output: Name: Mr. Meow, Breed: Tabby, Color: Ginger

/* --------------------------------------------*/
/* -- Builder Pattern with 'Director' usage -- */
/* --------------------------------------------*/

// Name won't be impacted by the type of cat we build,
// so we'll set the name on the builder beforehand.
var houseCatBuilder = new CatBuilder().WithName("Whiskers");

// Pass our builder into the director/creator class
var houseCatCreator = new CatCreator(houseCatBuilder);

// Use the director/creator to build a pre-defined cat type
var houseCat = houseCatCreator.BuildHouseCat();

// Here is another example, using the other defined cat type method
var showCatBuilder = new CatBuilder().WithName("Bella");
var showCatCreator = new CatCreator(showCatBuilder);
var showCat = showCatCreator.BuildShowCat();

Console.WriteLine(houseCat.ToString()); // Output: Name: Whiskers, Breed: Domestic Shorthair, Color: Gray
Console.WriteLine(showCat.ToString()); // Output: Name: Bella, Breed: Persian, Color: White
