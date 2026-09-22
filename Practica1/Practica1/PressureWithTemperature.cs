using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class PressureWithTemperature: Pressure
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public PressureWithTemperature() { }

        public override void FromStr(string f)
        {
            base.FromStr(f);
            string[] values = f.Trim().Split(' ');
            if (values.Length == 7)
            {
                try
                {
                    Temperature = double.Parse(values[5]);
                    Humidity = double.Parse(values[6]);
                }
                catch {
                    throw new Exception("Ошибка обработки данных");
                }
            }
            else {
                throw new Exception("Неправильный формат строки");
            }
        }

        public override string ToString()
        {
            return $"Дата: {Date}, Высота: {Height}, Значение: {Value}, Широта: {Shirota}, Долгота: {Dolgota}, Температура: {Temperature}, Влажность: {Humidity}";
        }
    }
}
