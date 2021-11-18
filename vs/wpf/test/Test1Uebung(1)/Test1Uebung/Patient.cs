using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Uebung
{
    class Patient
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Krankheit> Krankheiten { get; set; }

        public override string ToString()
        {
            return $"{Firstname} {Lastname}";
        }

        public string ToCSVString()
        {
            string s = $"{Firstname};{Lastname};";
            foreach (Krankheit krankheit in Krankheiten)
            {
                s += krankheit.ToCSVString();
            }
            return s;
        }


        public static bool TryParse(string s, out Patient p)
        {
            if(s is string)
            {
                string[] strArr = s.Split(';');
                if (strArr.Length >= 2)
                {
                    List<Krankheit> krankheiten = new List<Krankheit>();

                    if (!string.IsNullOrEmpty(strArr[2]))
                    {
                        string[] krkArr = strArr[2].Split('~');
                        foreach(string krk in krkArr)
                        {
                            if (!string.IsNullOrEmpty(krk))
                            {
                                string[] tmp = krk.Split('#');
                                krankheiten.Add(new Krankheit() { X = double.Parse(tmp[0]), Y = double.Parse(tmp[1]), Name = tmp[2] });
                            }

                        }

                    }

                    p = new Patient()
                    {
                        Firstname = strArr[0],
                        Lastname = strArr[1],
                        Krankheiten = krankheiten

                    };
                    return true;
                }
            }

            p = new Patient();
            return false;
        }
    }
}
