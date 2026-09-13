using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class PressureWithTemperature: Pressure
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }

        public PressureWithTemperature() { }
    }
}
