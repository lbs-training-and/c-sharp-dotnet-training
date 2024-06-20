// IWorker.cs
public interface IWorker
{
    void Work();
}

// IEater.cs
public interface IEater
{
    void Eat();
}

// HumanWorker.cs
public class HumanWorker : IWorker, IEater
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
}