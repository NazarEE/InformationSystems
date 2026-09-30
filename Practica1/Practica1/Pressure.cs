using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Pressure
    {
        public DateTime Date { get; set; }
        public double Height { get; set; }
        public int Value { get; set; }
        public double Shirota { get; set; }
        public double Dolgota { get; set; }

        public Pressure() { }

        public virtual void FromStr(string f)
        {
            try
            {
                string[] values = f.Trim().Split(' ');
                if (values.Length >= 6)
                {
                    Date = DateTime.Parse(values[1], CultureInfo.InvariantCulture);
                    Height = double.Parse(values[2], CultureInfo.InvariantCulture);
                    Value = int.Parse(values[3], CultureInfo.InvariantCulture);
                    Shirota = double.Parse(values[4], CultureInfo.InvariantCulture);
                    Dolgota = double.Parse(values[5], CultureInfo.InvariantCulture);
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
            return $"Дата: {Date}, Высота: {Height}, Значение: {Value}, Широта: {Shirota}, Долгота: {Dolgota}";
        }
    }
}
