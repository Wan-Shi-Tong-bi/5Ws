using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class MeasureValue
    {
        public int MeasureValueId { get; set; }
        public int SamplePosition { get; set; }
        public double MValue { get; set; }

        public virtual Measurment Measurment { get; set; }

    }
}
