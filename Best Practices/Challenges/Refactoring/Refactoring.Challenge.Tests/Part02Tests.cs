using FluentAssertions;

namespace Refactoring.Challenge.Tests
{
    [TestFixture]
    public class Part02Tests
    {
        [Test]
        public void FindMax_WithValidNumbers_ReturnsMaxValue()
        {
            var part = new Part02();
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            var result = part.Run(numbers);
            result.Should().Be(5);
        }
    }
}
