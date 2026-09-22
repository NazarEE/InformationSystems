using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practica1
{
    internal class FunctionsForFiles
    {
        public string[] ReadFromFile(string fileName)
        {
            try { 
                return File.ReadAllLines(fileName); 
            }
            catch
            {
                throw new Exception("Ошибка в имени файла");
            }
        }
    }
}
