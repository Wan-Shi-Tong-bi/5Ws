using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krankenhausverwaltung
{
    class Patient
    {
        public int SVNr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Branch Branch { get; set; }
        public HashSet<string> Disease { get; set; }


        public override string ToString()
        {
            return $"SVNr: {this.SVNr}; FirstName: {this.FirstName}; LastName: {this.LastName}; Branch: {BranchClass.BranchToString(this.Branch)}; Disease {string.Join(";", this.Disease)}";
        }

        public string ToCsvString()
        {
            return $"{this.SVNr};{this.FirstName};{this.LastName};{this.Branch};{string.Join(";", this.Disease)}";
        }

        public static Patient TryParse(string csvString) 
        {
            var splitedCsvString = csvString.Split(';');

            HashSet<string> diseases = new HashSet<string>();

            for (int i = 4; i < splitedCsvString.Length; i++)
                diseases.Add(splitedCsvString[i]);


            return new Patient
            {
                SVNr = int.Parse(splitedCsvString[0]),
                FirstName = splitedCsvString[1],
                LastName = splitedCsvString[2],
                Branch = (Branch)Enum.Parse(typeof(Branch), splitedCsvString[3]),
                Disease  =diseases
                
            };
        }
    }
}
