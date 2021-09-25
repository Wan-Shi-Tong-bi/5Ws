using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Position
    {
        public  int PosX { get; set; }

        public  int PosY { get; set; }

        public override string ToString()
        {
            return $"{PosX}{PosY}";
        }

        public static Position Parse(string chessInput)
        {
            var let = new Dictionary<char,int>{ { 'a' , 1}, { 'b', 2 }, { 'c', 3 }, { 'd', 4 }, { 'e', 5 }, { 'f', 6 }, { 'g', 7 }, { 'h', 8 } };
            int  x = let[chessInput[0]];
            int y = int.Parse(chessInput[1].ToString());
            return new Position { PosX=x,PosY=y};
        }
    }
}
