using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Runner: PlayFigure
    {
        public override bool IsWhite { get; set; }
        public override char Fig { get; } = 'L';

        public override bool CanMove(Position moveFrom, Position moveTo, ref Dictionary<string, PlayFigure> figDic)
        {
            int y = moveFrom.PosY;
            int x = moveFrom.PosX;
            while (true)
            {
                if (x == moveTo.PosX && y == moveTo.PosY)
                {
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
                }
                if (moveFrom.PosX > moveTo.PosX)
                {
                    x--;
                }
                else
                {
                    x++;
                }
                if (moveFrom.PosY > moveTo.PosY)
                {
                    y--;
                }
                else
                {
                    y++;
                }
                try
                {
                    var tmp = figDic[new Position { PosY = y, PosX = x }.ToString()].IsWhite;
                    
                }
                catch (KeyNotFoundException)
                {

                }
            }
        }
    }
}
