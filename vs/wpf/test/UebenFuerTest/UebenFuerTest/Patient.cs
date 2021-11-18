using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UebenFuerTest
{
    class Patient
    {
        public int svnr { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public DateTime birthday { get; set; }
        public List<Krankheit> krankheiten { get; set; }

        public static bool TryParse(string line, out Patient p)
        {
            p = new Patient();
            string[] words = line.Split(';');
            int sv = int.Parse(words[0]);
            string vname = words[1];
            string lname = words[2];
            DateTime bday = DateTime.Parse(words[3]);
            List<Krankheit> krankheiten = new List<Krankheit>();
            if(words.Length >= 4)
            {
                
            }
            return false;
        }
            
    }
}
