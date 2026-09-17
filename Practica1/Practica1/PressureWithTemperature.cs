using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class PressureWithTemperature: Pressure
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public PressureWithTemperature() { }

        public override void FromStr(string f)
        {
            base.FromStr(f);
            string[] values = f.Split(' ');
            Temperature = double.Parse(values[5]);
            Humidity = double.Parse(values[6]);
        }

        public override string ToString()
        {
            return $"Дата: {Date}, Высота: {Height}, Значение: {Value}, Широта: {Shirota}, Долгота: {Dolgota}, Температура: {Temperature}, Влажность: {Humidity}";
        }
    }
}
