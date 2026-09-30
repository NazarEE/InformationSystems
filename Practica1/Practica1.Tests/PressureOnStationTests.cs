using System;
using Practica1;
using Xunit;

namespace Practica1.Tests
{
    public class PressureOnStationTests
    {
        [Fact]
        public void FromStr_ValidString_ParsesAllFields()
        {
            PressureOnStation p = new PressureOnStation();
            string input = "pressureonstation 2026.10.10 10 34 35 45 Sever true";

            p.FromStr(input);

            Assert.Equal(new DateTime(2026, 10, 10), p.Date);
            Assert.Equal(10.0, p.Height);
            Assert.Equal(34.0, p.Value);
            Assert.Equal(35.0, p.Shirota);
            Assert.Equal(45.0, p.Dolgota);
            Assert.Equal("Sever", p.StationName);
            Assert.True(p.CorrectData);
        }

        [Fact]
        public void FromStr_WrongFieldCount_ThrowsException()
        {
            PressureOnStation p = new PressureOnStation();
            string input = "pressureonstation 2026.10.10 10 34 35 45 Sever";

            Assert.Throws<Exception>(() => p.FromStr(input));
        }

        [Fact]
        public void FromStr_InvalidBool_ThrowsException()
        {
            PressureOnStation p = new PressureOnStation();
            string input = "pressureonstation 2026.10.10 10 34 35 45 Sever notbool";

            Assert.Throws<Exception>(() => p.FromStr(input));
        }
    }
}
