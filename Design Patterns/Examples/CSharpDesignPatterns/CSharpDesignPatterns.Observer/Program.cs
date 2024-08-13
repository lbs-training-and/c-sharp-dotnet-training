using CSharpDesignPatterns.Observer;
using CSharpDesignPatterns.Observer.Models;

// Create the 'subject'
var cat = new Cat();

// Create the observers that need to be informed
// of things that happen to the subject (the cat)
var owner = new OwnerObserver();
var vet = new VetObserver();

// Register the observers against the subject
cat.AddObserver(owner);
cat.AddObserver(vet);

// Now, when the cat meows...
cat.Meow();

// We get the following output:
// The cat says: Meow!
// Owner has been notified: The cat just meowed.
// Vet has been notified: The cat just meowed.