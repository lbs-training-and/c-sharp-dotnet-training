using CSharpDesignPatterns.Strategy;
using CSharpDesignPatterns.Strategy.Models;

// Create specific behaviours
var friendlyBehaviour = new FriendlyBehaviour();
var aggressiveBehaviour = new AggressiveBehaviour();

// Create a friendly cat
var cat = new Cat(friendlyBehaviour);
cat.DisplayAnimalType(); // Output: This is a cat.

// Try and interact with the cat and see what happens
cat.PerformInteract(); // Output: The animal is friendly and will let you pet it.

// Maybe we need to turn our cat into a guard cat?!
// We cam set it's behaviour to be aggressive...
cat.SetBehavior(aggressiveBehaviour);

// Now, if someone tries to interact with it...
cat.PerformInteract(); // Output: The animal growls and shows its teeth.

// Yikes!