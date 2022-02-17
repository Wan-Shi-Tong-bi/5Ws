using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Measurment
    {
        public int MeasurmentId { get; set; }
        public string MeasureType { get; set; }
        public DateTime Start { get; set; }
        public int SampleRate { get; set; }

        public virtual List<MeasureValue> MeasureValues { get; set; }
        public virtual Patient Patient {get; set;}

        public Measurment()
        {
            MeasureValues = new List<MeasureValue>();
        }

        public static bool TryParse(object mayPatient, out Measurment measurment)
        {
            measurment = null;
            try
            {
                measurment = (Measurment)mayPatient;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{MeasureType } {SampleRate} ms [{MeasureValues.Count}]";
        }
    }
}
