// IWorker.cs
public interface IWorker
{
    void Work();
    void Eat();
}

// HumanWorker.cs
public class HumanWorker : IWorker
{
    public void Work()
    {
        // Working logic
    }

    public void Eat()
    {
        // Eating logic
    }
}

// RobotWorker.cs
public class RobotWorker : IWorker
{
    public void Work()
    {
        // Working logic
    }

    public void Eat()
    {
        throw new NotImplementedException("Robots do not eat.");
    }
}