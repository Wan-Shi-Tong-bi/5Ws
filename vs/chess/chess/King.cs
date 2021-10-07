using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class King: PlayFigure  
    {
        public override bool IsWhite { get; set; }
        public override char Fig { get; } = 'K';

        public override bool CanMove(Position moveFrom, Position moveTo, ref Dictionary<string, PlayFigure> figDic)
        {
            int yDiff = moveFrom.PosY - moveTo.PosY;
            int xDiff = moveFrom.PosX - moveTo.PosX;
            if ((xDiff <= 1 && xDiff >= -1) && (yDiff <= 1 && yDiff >= -1) )
            {
                try
                {
                    if( figDic[moveTo.ToString()].IsWhite == figDic[moveFrom.ToString()].IsWhite)
                    {
                        return false;
                    }
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
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
