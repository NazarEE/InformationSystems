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
            List<Pressure> pressures = new List<Pressure>();

            while (true)
            {
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1 - добавить объект");
                Console.WriteLine("2 - считать из файла");
                Console.WriteLine("3 - список объектов");
                Console.WriteLine("0 - выход");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите строку с данными(например, 2026.09.10 10 34 35 45): ");
                        string user_data = Console.ReadLine();
                        string[] data = { user_data };
                        foreach (Pressure p in InitObjects(data))
                        {
                            pressures.Add(p);
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите имя файла (например, data.txt)");
                        string filename = Console.ReadLine();
                        string[] datafromfile = ReadFromFile(filename);
                        foreach (Pressure p in InitObjects(datafromfile))
                        {
                            pressures.Add(p);
                        }
                        break;
                    case "3":
                        foreach(Pressure p in pressures)
                        {
                            Console.WriteLine(p.ToString());
                        }
                        break;
                    case "0":
                        return;
                }
            ;


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
