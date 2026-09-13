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
    }
}
