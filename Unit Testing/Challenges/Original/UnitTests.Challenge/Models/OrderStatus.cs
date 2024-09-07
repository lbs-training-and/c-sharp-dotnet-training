namespace UnitTests.Challenge.Models;

public enum OrderStatus
{
    Confirmed = 1,
    AwaitingDispatched = 2,
    Dispatched = 3,
    InTransit = 4,
    Delivered = 5,
    Cancelled = 6
}