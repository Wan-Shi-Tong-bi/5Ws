using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientVerwaltungWpf
{
    class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public bool BedWetter { get; set; }
        public bool IsMale { get; set; }
        public List<string> Diseases { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Birthday} BedWetter:{this.BedWetter} IsMail:{this.IsMale} List:{{{string.Join(",", this.Diseases)}}}";
        }


        public string ToStringName()
        {
            return $"{this.FirstName} {this.LastName}";
        }
        public string WriteFileString()
        {
            string listCsv = "";
            foreach (var item in this.Diseases)
            {
                listCsv += item+";";
            }
            return $"{this.FirstName};{this.LastName};{this.Birthday};{this.BedWetter};{this.IsMale};{listCsv}";
        }
        public static bool TryParse(string s, out Patient p)
        {
            var patientStringList = s.Split(';');

            List<string> diseaseFromCsv = new List<string>();
            for (int i = 5; i < patientStringList.Length; i++)
            {
                diseaseFromCsv.Add(patientStringList[i]);
            }

            p = new Patient
            {
                FirstName = patientStringList[0],
                LastName = patientStringList[1],
                Birthday = DateTime.Parse(patientStringList[2]),
                BedWetter = bool.Parse(patientStringList[3]),
                IsMale = bool.Parse(patientStringList[4]),
                Diseases = diseaseFromCsv
            };
            return true;
        }
    }
}

