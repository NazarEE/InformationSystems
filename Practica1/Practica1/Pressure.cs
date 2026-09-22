using System;
using System.Collections.Generic;
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
            string[] values = f.Trim().Split(' ');
            if (values.Length == 5)
            {
                try
                {
                    Date = DateTime.Parse(values[0]);
                    Height = double.Parse(values[1]);
                    Value = int.Parse(values[2]);
                    Shirota = double.Parse(values[3]);
                    Dolgota = double.Parse(values[4]);
                }
                catch {
                    throw new Exception("Ошибка обработки данных");
                }
            }
            else
            {
                throw new Exception("Неправильный формат строки");
            }
        }

        public override string ToString() {
            return $"Дата: {Date}, Высота: {Height}, Значение: {Value}, Широта: {Shirota}, Долгота: {Dolgota}";
        }

    }
}