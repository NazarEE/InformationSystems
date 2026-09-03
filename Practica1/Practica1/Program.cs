using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String s = Console.ReadLine();
            Pressure p1 = new Pressure();
            p1.FromStr(s);
            string[] result = { $"Дата: {p1.Date}, Высота: {p1.Height}, Значение: {p1.Value}, Широта: {p1.Shirota}, Долгота: {p1.Dolgota}" };
            File.WriteAllLines("file.txt" +
                "", result);

        }
    }
}
