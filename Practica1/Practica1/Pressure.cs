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

        public void FromStr(string f)
        {
            string[] values = f.Trim().Split(' ');
            Date = DateTime.Parse(values[0]);
            Height = double.Parse(values[1]);
            Value = int.Parse(values[2]);
            Shirota = double.Parse(values[3]);
            Dolgota = double.Parse(values[4]);

        }

    }
}