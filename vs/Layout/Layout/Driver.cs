using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout
{
    class Driver
    {
        public string DriverName { get; set; }
        public Car DriverCar { get; set; }

        public override string ToString()
        {
            return $"{DriverName}: {DriverCar.Brand} {DriverCar.PS} PS";
        }
    }
}
