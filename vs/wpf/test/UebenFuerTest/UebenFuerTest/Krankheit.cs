using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace UebenFuerTest
{
    class Krankheit
    {
        public string krankheit { get; set; }
        public List<string> points { get; set; }

        public static bool TryParse(string line, out Krankheit k)
        {
            k = new Krankheit();
            string[] words = line.Split('#');
            string krank = words[0];
            List<string> point = new List<string>();
            if (words.Length >= 1)
            {
                foreach(var word in words)
                {
                    point.Add(word);
                }
            }
            k = new Krankheit
            {
                krankheit = krank,
                points = point
            };
            return true;
        }
    } 
}
    

