using FluentAssertions;

namespace Example.Source._TemperatureConverter
{
    public class TemperatureConverterTests
    {
        private readonly TemperatureConverter _converter = new TemperatureConverter();

        [Fact]
        public void CelsiusToAll_ReturnsTheSameCelsius()
        {
            var inputCelsius = 1;

            var temperatures = _converter.CelsiusToAll(inputCelsius);

            temperatures.Celsius.Should().Be(inputCelsius);
        }

        [Theory]
        [InlineData(0, 273.15)]
        [InlineData(1, 274.15)]
        public void CelsiusToAll_ReturnsConvertedKelvin(double celsius, double expectedKelvin)
        {
            var temperatures = _converter.CelsiusToAll(celsius);

            temperatures.Kelvin.Should().Be(expectedKelvin);
        }

        [Theory]
        [InlineData(0, 32)]
        [InlineData(5, 41)]
        public void CelsiusToAll_ReturnsConvertedFaherenheit(double celsius, double expectedFahrenheit)
        {
            var temperatures = _converter.CelsiusToAll(celsius);

            temperatures.Fahrenheit.Should().Be(expectedFahrenheit);
        }

        public Temperatures CelsiusToAll(double celsius) => new Temperatures 
        { 
            Celsius = celsius,
            Kelvin = celsius + 273.15,
            Fahrenheit = (9d / 5d * celsius) + 32
        };
    }
}
