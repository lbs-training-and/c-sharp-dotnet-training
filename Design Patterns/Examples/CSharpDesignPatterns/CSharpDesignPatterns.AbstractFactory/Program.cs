using CSharpDesignPatterns.AbstractFactory;

var catFactory = new CatFactory();
var myCat = catFactory.CreateAnimal();
var myCatFood = catFactory.CreateAnimalFood();

var dogFactory = new DogFactory();
var myDog = dogFactory.CreateAnimal();
var myDogFood = dogFactory.CreateAnimalFood();

Console.WriteLine($"My cat says '{myCat.Speak()}' It eats {myCatFood.GetFoodName()}."); // Outputs: My cat says 'Meow!' It eats Purrrfectly Posh Nosh.
Console.WriteLine($"My dog says '{myDog.Speak()}' It eats {myDogFood.GetFoodName()}."); // Outputs: Woof! My dog says 'Woof!' It eats Howlin' Chow.