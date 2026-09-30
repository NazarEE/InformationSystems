using System;
using Practica1;
using Xunit;

namespace Practica1.Tests
{
    public class PressureWithTemperatureTests
    {
        [Fact]
        public void FromStr_ValidString_ParsesTemperatureAndHumidity()
        {
            PressureWithTemperature p = new PressureWithTemperature();
            string input = "pressurewithtemperature 2024.09.10 34 35 36 37 15.5 16";

            p.FromStr(input);

            Assert.Equal(new DateTime(2024, 9, 10), p.Date);
            Assert.Equal(34.0, p.Height);
            Assert.Equal(35.0, p.Value);
            Assert.Equal(36.0, p.Shirota);
            Assert.Equal(37.0, p.Dolgota);
            Assert.Equal(15.5, p.Temperature);
            Assert.Equal(16.0, p.Humidity);
        }

        [Fact]
        public void FromStr_WrongFieldCount_ThrowsException()
        {
            PressureWithTemperature p = new PressureWithTemperature();
            string input = "pressurewithtemperature 2024.09.10 34 35 36 37 15";

            Assert.Throws<Exception>(() => p.FromStr(input));
        }

        [Fact]
        public void ToString_ContainsTemperatureAndHumidity()
        {
            PressureWithTemperature p = new PressureWithTemperature
            {
                Date = new DateTime(2026, 9, 10),
                Height = 10,
                Value = 34,
                Shirota = 35,
                Dolgota = 45,
                Temperature = 22.5,
                Humidity = 60.1,
            };

            string result = p.ToString();

            Assert.Contains("Температура: 22,5", result.Replace('.', ','));
            Assert.Contains("Влажность: 60,1", result.Replace('.', ','));
        }
    }
}
