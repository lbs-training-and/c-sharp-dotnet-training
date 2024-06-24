// Bird.cs
public class Bird
{
    public virtual void Fly()
    {
        // Fly logic for birds
    }
}

// Sparrow.cs
public class Sparrow : Bird
{
    public override void Fly()
    {
        // Fly logic for sparrows
    }
}

// Penguin.cs
public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotImplementedException("Penguins cannot fly.");
    }
}