using System.Collections.Generic;
using Practica1;
using Xunit;

namespace Practica1.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void AddToListPressure_AddsParsedObjects()
        {
            var list = new List<Pressure>();
            string[] data =
            {
                "pressure 2026.09.10 10 34 35 45",
                "pressureOnStation 2026.09.12 12 36 37 47 Sever true",
            };

            Program.AddToListPressure(data, list);

            Assert.Equal(2, list.Count);
            Assert.IsType<PressureOnStation>(list[1]);
        }
    }
}
