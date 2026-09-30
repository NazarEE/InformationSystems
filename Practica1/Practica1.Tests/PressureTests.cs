using System;
using Practica1;
using Xunit;

namespace Practica1.Tests
{
    public class PressureTests
    {
        [Fact]
        public void FromStr_ValidString_ParsesAllFields()
        {
            var p = new Pressure();
            string input = "Pressure 2026.09.10 10 34 35 45";

            p.FromStr(input);

            Assert.Equal(new DateTime(2026, 9, 10), p.Date);
            Assert.Equal(10.0, p.Height);
            Assert.Equal(34.0, p.Value);
            Assert.Equal(35.0, p.Shirota);
            Assert.Equal(45.0, p.Dolgota);
        }

        [Fact]
        public void FromStr_TooFewFields_ThrowsException()
        {
            var p = new Pressure();
            string input = "Pressure 2026.09.10 10 34";

            var ex = Assert.Throws<Exception>(() => p.FromStr(input));
            Assert.Equal("Ошибка обработки данных", ex.Message);
        }

        [Fact]
        public void FromStr_InvalidDateFormat_ThrowsException()
        {
            var p = new Pressure();
            string input = "Pressure not-a-date 10 34 35 45";

            Assert.Throws<Exception>(() => p.FromStr(input));
        }

        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            var p = new Pressure
            {
                Date = new DateTime(2026, 9, 10),
                Height = 10,
                Value = 34,
                Shirota = 35,
                Dolgota = 45,
            };

            string result = p.ToString();

            Assert.Contains("Дата:", result);
            Assert.Contains("2026", result);
            Assert.Contains("Значение: 34", result);
        }
    }
}
