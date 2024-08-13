using CSharpDesignPatterns.Command;
using CSharpDesignPatterns.Command.Models;

// Create classes to use with commands
// These are known as 'receivers'
var cat = new Cat();
var dog = new Dog();

// Create the commands and then
// pass the relevant receiver in
var meowCommand = new MeowCommand(cat);
var barkCommand = new BarkCommand(dog);

// Create the 'invoker'
// This is what will take in our commands
// and then execute them when told to do so
var invoker = new AnimalInvoker();

// Set and execute the meow command
invoker.SetCommand(meowCommand);
invoker.ExecuteCommand(); // Output: The cat says: Meow!

// Set and execute the bark command
invoker.SetCommand(barkCommand);
invoker.ExecuteCommand(); // Output: The dog says: Woof!
