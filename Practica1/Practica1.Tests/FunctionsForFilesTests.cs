using System;
using System.IO;
using Practica1;
using Xunit;

namespace Practica1.Tests
{
    public class FunctionsForFilesTests : IDisposable
    {
        private readonly FunctionsForFiles _sut;
        private readonly string _tempFile;

        public FunctionsForFilesTests()
        {
            _sut = new FunctionsForFiles();
            _tempFile = Path.Combine(Path.GetTempPath(), $"test_{Guid.NewGuid()}.txt");
        }

        public void Dispose()
        {
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        [Fact]
        public void ReadFromFile_ValidFile_ReturnsNonEmptyLines()
        {
            File.WriteAllLines(
                _tempFile,
                new[]
                {
                    "pressure 2026.09.10 10 34 35 45",
                    "",
                    "pressure 2026.09.11 11 35 36 46",
                    "   ",
                }
            );

            string[] result = _sut.ReadFromFile(_tempFile);

            Assert.Equal(2, result.Length);
            Assert.Equal("pressure 2026.09.10 10 34 35 45", result[0]);
            Assert.Equal("pressure 2026.09.11 11 35 36 46", result[1]);
        }

        [Fact]
        public void ReadFromFile_EmptyFile_ReturnsEmptyArray()
        {
            File.WriteAllText(_tempFile, string.Empty);

            string[] result = _sut.ReadFromFile(_tempFile);

            Assert.Empty(result);
        }

        [Fact]
        public void ReadFromFile_NonExistentFile_ThrowsFileNotFoundException()
        {
            string missing = Path.Combine(Path.GetTempPath(), $"missing_{Guid.NewGuid()}.txt");

            Assert.Throws<FileNotFoundException>(() => _sut.ReadFromFile(missing));
        }
    }
}
