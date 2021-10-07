using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Knigth:PlayFigure
    {
        public override bool IsWhite { get; set; }
        public override char Fig { get; } = 'S';

        public override bool CanMove(Position moveFrom, Position moveTo, ref Dictionary<string, PlayFigure> figDic)
        {
            int yDiff = moveFrom.PosY - moveTo.PosY <0 ? (moveFrom.PosY - moveTo.PosY) * -1: moveFrom.PosY - moveTo.PosY;
            int xDiff = moveFrom.PosX - moveTo.PosX < 0 ? (moveFrom.PosX - moveTo.PosX) * -1: moveFrom.PosX - moveTo.PosX;
            if ((yDiff == 2 && xDiff == 1) || (xDiff == 2 && yDiff == 1))
            {
                try
                {
                    if (figDic[moveFrom.ToString()].IsWhite != figDic[moveTo.ToString()].IsWhite) 
                    {
                        figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                        figDic.Remove(moveFrom.ToString());
                        return true;
                    }
                    return false;
                }
                catch (KeyNotFoundException)
                {
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
                }
            }
            return false;
        }
    }
}
