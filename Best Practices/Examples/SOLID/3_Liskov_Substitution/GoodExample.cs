// IBird.cs
public interface IBird
{
    void Move();
}

// IFlyingBird.cs
public interface IFlyingBird : IBird
{
    void Fly();
}

// Sparrow.cs
public class Sparrow : IFlyingBird
{
    public void Move()
    {
        // Move logic for sparrows
    }

    public void Fly()
    {
        // Fly logic for sparrows
    }
}

// Penguin.cs
public class Penguin : IBird
{
    public void Move()
    {
        // Move logic for penguins
    }
}