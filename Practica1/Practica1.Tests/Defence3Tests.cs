using System.Collections.Generic;
using System.Reflection.Metadata;
using Practica1;
using Xunit;

namespace Practica1.Tests
{
    public class Defence3Tests
    {
        [Fact]
        public void Defence3_CorrectData_CheckOutput()
        {
            Dictionary<string, List<List<string>>> graf =
                new Dictionary<string, List<List<string>>>();
            graf.Add(
                "A",
                new List<List<string>>()
                {
                    new List<string>() { "E" },
                    new List<string>() { "F" },
                }
            );
            graf.Add(
                "B",
                new List<List<string>>()
                {
                    new List<string>() { "A", "C" },
                    new List<string>(),
                }
            );
            graf.Add(
                "C",
                new List<List<string>>()
                {
                    new List<string>() { "D", "E" },
                    new List<string>(),
                }
            );
            graf.Add(
                "D",
                new List<List<string>>()
                {
                    new List<string>() { },
                    new List<string>(),
                }
            );
            graf.Add(
                "E",
                new List<List<string>>()
                {
                    new List<string>() { },
                    new List<string>(),
                }
            );
            graf.Add(
                "F",
                new List<List<string>>()
                {
                    new List<string>() { },
                    new List<string>(),
                }
            );

            string input_string = "A --|> B\nC --|> B\nE --|> A\nD --|> C\nF --|> C\nA 0-> E";

            Dictionary<string, List<List<string>>> result = Program.Defence3(input_string);

            Assert.Equal(result, graf);
        }

        [Fact]
        public void Defence3_InvalidInput_ReturnsError()
        {
            string input = "AA_---dsddfdf";
            var ex = Assert.Throws<Exception>(() => Program.Defence3(input));
            Assert.Equal("Неправильный формат входных данных", ex.Message);
        }
    }
}
