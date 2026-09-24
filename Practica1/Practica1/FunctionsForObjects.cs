using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class FunctionsForObjects
    {
        public void AddDayToMinDate(Pressure[] pressures)
        {
            if (pressures.Length != 0)
            {
                DateTime dateTime = pressures[0].Date;
                int index = 0;
                int result_index = 0;
                foreach (Pressure p in pressures)
                {
                    if (p.Date < dateTime)
                    {
                        dateTime = p.Date;
                        result_index = index;
                    }
                    index += 1;
                }
                pressures[result_index].Date = pressures[result_index].Date.AddDays(1);
            }
            else
            {
                throw new Exception("Массив данных пустой");
            }
        }

        public List<Pressure> InitObjects(string[] strings)
        {
            List<Pressure> result = new List<Pressure>();
            foreach (string s in strings)
            {
                string[] s1 = s.Trim().Split(' ');
                if (s1[0].ToLower() == "pressure")
                {
                    Pressure p = new Pressure();
                    p.FromStr(s);
                    result.Add(p);
                }
                else if (s1[0].ToLower() == "pressurewithtemperature")
                {
                    PressureWithTemperature p = new PressureWithTemperature();
                    p.FromStr(s);
                    result.Add(p);
                }
                else if (s1[0].ToLower() == "pressureonstation")
                {
                    PressureOnStation p = new PressureOnStation();
                    p.FromStr(s);
                    result.Add(p);
                }
                else
                {
                    throw new Exception("Неверный тип данных");
                }
            }
            return result;
        }
    }
}
