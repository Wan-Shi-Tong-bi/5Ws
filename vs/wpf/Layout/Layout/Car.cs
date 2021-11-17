using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Layout
{
    [TypeConverter(typeof(CarConverter))]
    class Car
    {
        public Car()
        {

        }
        public Car(string s, int i)
        {
            Brand = s;
            PS = i;
        }
        public string Brand { get; set; }
        public int PS { get; set; }
    }
}
