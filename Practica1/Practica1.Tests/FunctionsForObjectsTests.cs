using System;
using System.Collections.Generic;
using Practica1;
using Xunit;

namespace Practica1.Tests
{
    public class FunctionsForObjectsTests
    {
        private readonly FunctionsForObjects _sut = new();

        [Fact]
        public void InitObjects_ParsesAllThreeTypes()
        {
            string[] input =
            {
                "pressure 2026.09.10 10 34 35 45",
                "pressureWithTemperature 2026.09.11 11 35 36 46 22.5 60.1",
                "pressureOnStation 2026.09.12 12 36 37 47 Sever true",
            };

            List<Pressure> result = _sut.InitObjects(input);

            Assert.Equal(3, result.Count);
            Assert.IsType<Pressure>(result[0]);
            Assert.IsType<PressureWithTemperature>(result[1]);
            Assert.IsType<PressureOnStation>(result[2]);
        }

        [Fact]
        public void InitObjects_TypeCaseInsensitive_Works()
        {
            string[] input = { "pressure 2026.09.10 10 34 35 45" };

            var result = _sut.InitObjects(input);

            Assert.Single(result);
            Assert.IsType<Pressure>(result[0]);
        }

        [Fact]
        public void InitObjects_UnknownType_ThrowsException()
        {
            string[] input = { "Unknown 2026.09.10 10 34 35 45" };

            var ex = Assert.Throws<Exception>(() => _sut.InitObjects(input));
            Assert.Equal("Неверный тип данных", ex.Message);
        }

        [Fact]
        public void InitObjects_EmptyInput_ReturnsEmptyList()
        {
            var result = _sut.InitObjects(Array.Empty<string>());
            Assert.Empty(result);
        }

        [Fact]
        public void AddDayToMinDate_IncrementsDateOfEarliestItem()
        {
            var pressures = new Pressure[]
            {
                new Pressure { Date = new DateTime(2026, 9, 10) },
                new Pressure { Date = new DateTime(2026, 9, 5) },
                new Pressure { Date = new DateTime(2026, 9, 20) },
            };

            _sut.AddDayToMinDate(pressures);

            Assert.Equal(new DateTime(2026, 9, 6), pressures[1].Date);
            Assert.Equal(new DateTime(2026, 9, 10), pressures[0].Date);
            Assert.Equal(new DateTime(2026, 9, 20), pressures[2].Date);
        }

        [Fact]
        public void AddDayToMinDate_SingleItem_Increments()
        {
            var pressures = new Pressure[] { new Pressure { Date = new DateTime(2026, 9, 10) } };

            _sut.AddDayToMinDate(pressures);

            Assert.Equal(new DateTime(2026, 9, 11), pressures[0].Date);
        }

        [Fact]
        public void AddDayToMinDate_EmptyArray_ThrowsException()
        {
            var pressures = Array.Empty<Pressure>();

            var ex = Assert.Throws<Exception>(() => _sut.AddDayToMinDate(pressures));
            Assert.Equal("Массив данных пустой", ex.Message);
        }

        [Fact]
        public void AddDayToMinDate_FirstItemIsMin_IncrementsFirst()
        {
            var pressures = new Pressure[]
            {
                new Pressure { Date = new DateTime(2026, 9, 1) },
                new Pressure { Date = new DateTime(2026, 9, 10) },
            };

            _sut.AddDayToMinDate(pressures);

            Assert.Equal(new DateTime(2026, 9, 2), pressures[0].Date);
        }

        [Fact]
        public void AddDayToMinDate_TiesIncrementsFirstFound()
        {
            var d = new DateTime(2026, 9, 5);
            var pressures = new Pressure[]
            {
                new Pressure { Date = d },
                new Pressure { Date = d },
            };

            _sut.AddDayToMinDate(pressures);

            Assert.Equal(new DateTime(2026, 9, 6), pressures[0].Date);
            Assert.Equal(new DateTime(2026, 9, 5), pressures[1].Date);
        }
    }
}
