using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class PressureOnStation : Pressure
    {
        public string StationName { get; set; }
        public bool CorrectData { get; set; }

        public PressureOnStation() { }

        public override void FromStr(string f)
        {
            try
            {
                base.FromStr(f);
                string[] values = f.Trim().Split(' ');
                if (values.Length == 8)
                {
                    StationName = values[6];
                    CorrectData = bool.Parse(values[7]);
                }
                else
                {
                    throw new Exception("Неверный формат строки");
                }
            }
            catch
            {
                throw new Exception("Ошибка обработки данных");
            }
        }

        public override string ToString()
        {
            return $"Дата: {Date}, Высота: {Height}, Значение: {Value}, Широта: {Shirota}, Долгота: {Dolgota}, Имя станции: {StationName}, Корректность данных: {CorrectData}";
        }
    }
}
