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
            FunctionsForObjects functionsforobjects = new FunctionsForObjects();
            FunctionsForFiles functionsforfiles = new FunctionsForFiles();

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
                        try
                        {
                            string[] data = { user_data };
                            foreach (Pressure p in functionsforobjects.InitObjects(data))
                            {
                                pressures.Add(p);
                            }
                        }
                        catch (Exception ex) {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите имя файла (например, data.txt)");
                        string filename = Console.ReadLine();
                        try
                        {
                            string[] datafromfile = functionsforfiles.ReadFromFile(filename);
                            foreach (Pressure p in functionsforobjects.InitObjects(datafromfile))
                            {
                                pressures.Add(p);
                            }
                        }
                        catch (Exception ex) {
                            Console.WriteLine($"Ошибка: {ex.Message}");
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
                };
            }
        }     
    }
}
