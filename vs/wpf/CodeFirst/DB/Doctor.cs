using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Doctor
    {
        public int DoctorID { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual List<Patient> Patients { get; set; }
        public Doctor()
        {
            Patients = new List<Patient>();
        }

        public override string ToString()
        {
            return $"{ Title} {Firstname} {Lastname}" ;
        }

        public static bool TryParse(object mayPatient, out Doctor doc)
        {
            doc = null;
            try
            {
                doc = (Doctor)mayPatient;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
