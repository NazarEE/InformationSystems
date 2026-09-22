using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class PressureOnStation : Pressure
    {
        public string StationName { get; set; }
        public bool CorrectData { get; set; }

        public PressureOnStation() { }

        public override void FromStr(string f)
        {
            base.FromStr(f);
            string[] values = f.Split(' ');
            if (values.Length == 7)
            {
                try
                {
                    StationName = values[5];
                    CorrectData = bool.Parse(values[6]);
                }
                catch {
                    throw new Exception("Ошибка обработки данных");
                }
            }
            else {
                throw new Exception("Неверный формат строки");
            }
        }

        public override string ToString()
        {
            return $"Дата: {Date}, Высота: {Height}, Значение: {Value}, Широта: {Shirota}, Долгота: {Dolgota}, Имя станции: {StationName}, Корректность данных: {CorrectData}";
        }
    }
}
