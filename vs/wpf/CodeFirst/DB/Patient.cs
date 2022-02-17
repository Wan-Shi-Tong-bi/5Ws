using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Patient
    {
        public int PatientID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Born { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual List<Measurment> Measurments { get; set; }

        public Patient()
        {
            Measurments = new List<Measurment>();
        }

        public override string ToString()
        {
            return $"{Firstname} {Lastname} [{Measurments.Count}]"; 
        }

        public static bool TryParse(object mayPatient, out Patient patient)
        {
            patient = null;
            try
            {
                patient = (Patient)mayPatient;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
