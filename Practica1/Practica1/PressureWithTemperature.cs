using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class PressureWithTemperature : Pressure
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public PressureWithTemperature() { }

        public override void FromStr(string f)
        {
            try
            {
                base.FromStr(f);
                string[] values = f.Trim().Split(' ');
                if (values.Length == 8)
                {
                    Temperature = double.Parse(values[6], CultureInfo.InvariantCulture);
                    Humidity = double.Parse(values[7], CultureInfo.InvariantCulture);
                }
                else
                {
                    throw new Exception("Неправильный формат строки");
                }
            }
            catch
            {
                throw new Exception("Ошибка обработки данных");
            }
        }

        public override string ToString()
        {
            return $"Дата: {Date}, Высота: {Height}, Значение: {Value}, Широта: {Shirota}, Долгота: {Dolgota}, Температура: {Temperature}, Влажность: {Humidity}";
        }
    }
}
