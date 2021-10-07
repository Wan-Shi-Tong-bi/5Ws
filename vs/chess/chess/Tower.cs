using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Tower : PlayFigure
    {
        public override bool IsWhite { get; set; }
        public override char Fig { get; } = 'T';

        public override bool CanMove(Position moveFrom, Position moveTo, ref Dictionary<string, PlayFigure> figDic)
        {
            int y = moveFrom.PosY;
            int x = moveFrom.PosX;
            if (x != moveTo.PosX && y != moveTo.PosY)
            {
                return false;
            }

            try
            {
                var tmp = figDic[moveTo.ToString()].IsWhite;
                
            }
            catch (KeyNotFoundException)
            {
                
            }

            while (true)
            {
                
                if (moveFrom.PosX > moveTo.PosX)
                {
                    x--;
                }
                else if (moveFrom.PosX < moveTo.PosX)
                {
                    x++;
                }
                else if (moveFrom.PosY > moveTo.PosY)
                {
                    y--;
                }
                else if (moveFrom.PosY < moveTo.PosY)
                {
                    y++;
                }
                if (x == moveTo.PosX && y == moveTo.PosY)
                {
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
                }
                try
                {
                    var tmp = figDic[new Position { PosY = y, PosX = x }.ToString()];
                    return false;
                }
                catch (KeyNotFoundException)
                {

                }
            }
        }
    }
}
