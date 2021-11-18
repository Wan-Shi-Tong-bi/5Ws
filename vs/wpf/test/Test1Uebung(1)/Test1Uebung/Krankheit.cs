using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Uebung
{
    class Krankheit
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public string ToCSVString()
        {
            return $"{X}#{Y}#{Name}~";
        }
    }
}
