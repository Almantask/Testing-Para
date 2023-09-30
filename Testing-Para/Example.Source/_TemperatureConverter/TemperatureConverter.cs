namespace Example.Source._TemperatureConverter
{
    // Assert each separately
    public class Temperatures
    {
        public double Celsius { get; set; }
        public double Kelvin { get; set; }
        public double Fahrenheit { get; set; }
    }

    public class TemperatureConverter
    {
        public Temperatures CelsiusToAll(double celsius) => new Temperatures 
        { 
            Celsius = celsius,
            Kelvin = celsius, // TODO
            Fahrenheit = celsius, // TODO
        };
    }
}
