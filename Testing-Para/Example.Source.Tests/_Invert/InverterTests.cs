using Example.Source._Invert;
using FluentAssertions;

namespace Example.Source.Tests._Invert
{
    public class InverterTests
    {
        private readonly Inverter _inverter = new Inverter();

        [Theory]
        [InlineData(1000000003)] // Keep it simple - the first digit that after inversion would go OB.
        [InlineData(-1000000003)]
        public void WhenOutOfRange_ReturnsInvalid0(int integer)
        {
            var reversed = _inverter.Reverse(integer);

            reversed.Should().Be(Inverter.Invalid);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(12, 21)]
        [InlineData(121, 121)]
        [InlineData(120, 21)]
        [InlineData(-1, -1)]
        [InlineData(-12, -21)]
        public void WhenInRange_ReturnsReversed(int integer, int expected)
        {
            var reversed = _inverter.Reverse(integer);

            reversed.Should().Be(expected);
        }
    }
}
