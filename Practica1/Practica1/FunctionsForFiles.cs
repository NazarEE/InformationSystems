using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class FunctionsForFiles
    {
        public string[] ReadFromFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                List<string> result = new List<string>();
                foreach (string line in lines)
                {
                    if (line.Trim().Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        result.Add(line);
                    }
                }
                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw new FileNotFoundException($"Не удалось прочитать файл: {fileName}", ex);
            }
        }
    }
}
