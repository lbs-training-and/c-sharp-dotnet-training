using AutoFixture;
using UnitTesting.Examples.AutoFixtureExamples;

namespace UnitTesting.Examples.Tests.AutoFixtureExamples;

[TestFixture]
public class OrderServiceTests
{
    [Test]
    public void CanUpdateStatus()
    {
        var fixture = new Fixture();

        var order = fixture.Create<Order>();

        var orders = fixture.CreateMany<Order>();

        var threeOrders = fixture.CreateMany<Order>(3);

        fixture.Customize<Order>(c => c
            .With(o => o.Id, Random.Shared.Next(0, 5))
            .With(o => o.Products, () => fixture.CreateMany<Product>(4).ToList())
            .Without(o => o.TotalPrice)
            .With(o => o.Status, OrderStatus.Accepted));

        var customisedOrder = fixture.Create<Order>();
    }
}