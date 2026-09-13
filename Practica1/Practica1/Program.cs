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
            /*String s = Console.ReadLine();
            Pressure p1 = new Pressure();
            p1.FromStr(s);
            string[] result = { $"Дата: {p1.Date}, Высота: {p1.Height}, Значение: {p1.Value}, Широта: {p1.Shirota}, Долгота: {p1.Dolgota}" };
            File.WriteAllLines("file.txt" +
                "", result);*/

            Pressure p0 = new Pressure();
            p0.FromStr("2026.09.10 10 34 35 45");
            Pressure p2 = new Pressure();
            p2.FromStr("2025.09.10 10 34 35 45");
            Pressure p3 = new Pressure();
            p3.FromStr("2024.09.09 10 34 35 45");
            Pressure[] pressures1 = { p0, p2, p3 };
            AddDayToMinDate(pressures1);
            Console.WriteLine($"Проверка функции добавления одного дня к минимальной дате: {p3.Date}");

            string[] data = ReadFromFile("data.txt");
            List<Pressure> pressures = InitObjects(data);
            Console.WriteLine("Проверка инициализации объектов:");
            foreach (Pressure p in pressures) { 
                Console.WriteLine(p.ToString());
            }


        }

        public static void AddDayToMinDate(Pressure[] pressures)
        {
            DateTime dateTime = pressures[0].Date;
            int index = 0;
            int res_index = -1;
            foreach (Pressure p in pressures) {
                if (p.Date < dateTime) {
                    dateTime = p.Date;
                    res_index = index;
                }
                index += 1;
            }
            pressures[res_index].Date = pressures[res_index].Date.AddDays(1);
             
        }

        public static string[] ReadFromFile(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        public static List<Pressure> InitObjects(string[] strings)
        {
            List<Pressure> result = new List<Pressure>();
            foreach (string s in strings) {
                string[] s1 = s.Split(' ');
                if (s1.Length == 5) {
                    Pressure p = new Pressure();
                    p.FromStr(s);
                    result.Add(p);
                }
                else if (s1.Length == 7 && int.TryParse(s1[5], out int res) && int.TryParse(s1[6], out int res1)) {
                    PressureWithTemperature p = new PressureWithTemperature();
                    p.FromStr(s);
                    result.Add(p);
                }
                else if (s1.Length == 7 && !int.TryParse(s1[5], out int res2) && !int.TryParse(s1[6], out int res3))
                {
                    PressureOnStation p = new PressureOnStation();
                    p.FromStr(s);
                    result.Add(p);
                }
                else
                {
                    Console.WriteLine("Ошибка");
                }
            }
            return result;
        }
        
    }
}
