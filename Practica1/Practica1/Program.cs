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
            Console.WriteLine($"{p3.Date}");


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

        
    }
}
