using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krankenhausverwaltung
{
    class Doctor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Branch Branch { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} Dr. {this.LastName}";
        }

        public string ToCsvString()
        {
            return $"{this.FirstName};{this.LastName};{this.Branch}";
        }

        public static Doctor TryParse(string csvString)
        {
            var splitedCsvString = csvString.Split(';');

            return new Doctor
            {
                FirstName = splitedCsvString[0],
                LastName = splitedCsvString[1],
                Branch = (Branch)Enum.Parse(typeof(Branch), splitedCsvString[2])
            };
        }
    }
}
