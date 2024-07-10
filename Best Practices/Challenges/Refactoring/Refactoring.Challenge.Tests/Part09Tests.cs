using FluentAssertions;

namespace Refactoring.Challenge.Tests
{
    [TestFixture]
    public class Part09Tests
    {
        [Test]
        public void CalculateStats_WithValidNumbers_ReturnsCorrectStats()
        {
            var part = new Part09();
            var numbers = new List<int> { 1, 2, 2, 3, 4 };

            var result = part.CalculateStats(numbers);

            result.Item1.Should().BeApproximately(2.4, 0.001);
            result.Item2.Should().Be(2);
            result.Item3.Should().Be(2);
        }

        [Test]
        public void CalculateStats_WithEvenNumberOfElements_ReturnsCorrectMedian()
        {
            var part = new Part09();
            var numbers = new List<int> { 1, 2, 3, 4 };

            var result = part.CalculateStats(numbers);

            result.Item1.Should().BeApproximately(2.5, 0.001);
            result.Item2.Should().Be(2.5);
            result.Item3.Should().BeOneOf(1, 2, 3, 4);
        }

        [Test]
        public void CalculateStats_WithSingleElement_ReturnsElementAsMeanMedianMode()
        {
            var part = new Part09();
            var numbers = new List<int> { 5 };

            var result = part.CalculateStats(numbers);

            result.Item1.Should().Be(5);
            result.Item2.Should().Be(5);
            result.Item3.Should().Be(5);
        }

        [Test]
        public void CalculateStats_WithNullList_ThrowsArgumentException()
        {
            var part = new Part09();

            var action = () => part.CalculateStats(null);

            action.Should().Throw<ArgumentException>().WithMessage("List is null or empty");
        }

        [Test]
        public void CalculateStats_WithEmptyList_ThrowsArgumentException()
        {
            var part = new Part09();
            var numbers = new List<int>();

            var action = () => part.CalculateStats(numbers);

            action.Should().Throw<ArgumentException>().WithMessage("List is null or empty");
        }
    }
}