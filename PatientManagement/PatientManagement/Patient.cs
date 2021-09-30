using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManagement
{
    class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public bool BedWetter { get; set; }
        public bool IsMale { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Birthday} BedWetter:{this.BedWetter} IsMail{this.IsMale}";
        }

        public string WriteFileString()
        {
            return $"{this.FirstName};{this.LastName};{this.Birthday};{this.BedWetter};{this.IsMale}";
        }
        public static bool TryParse(string s, out Patient p)
        {
            var patientStringList = s.Split(';');

            p = new Patient
            {
                FirstName = patientStringList[0],
                LastName = patientStringList[1],
                Birthday = DateTime.Parse(patientStringList[2]),
                BedWetter = bool.Parse(patientStringList[3]),
                IsMale = bool.Parse(patientStringList[4])
            };
            return true;
        }
    }
}
