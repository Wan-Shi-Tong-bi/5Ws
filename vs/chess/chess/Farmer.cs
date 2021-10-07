using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Farmer : PlayFigure
    {
        public override bool IsWhite { get; set; }
        public override char Fig { get; } = 'B';

        public override bool CanMove(Position moveFrom, Position moveTo, ref Dictionary<string, PlayFigure> figDic)
        {
            try
            {
                PlayFigure fig = figDic[moveTo.ToString()];
                if (((moveTo.PosY == moveFrom.PosY + 1) && ((moveTo.PosX == moveFrom.PosX - 1) || (moveTo.PosX == moveFrom.PosX + 1))) && figDic[moveFrom.ToString()].IsWhite)
                {
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
                }
                else if (((moveTo.PosY == moveFrom.PosY - 1) && ((moveTo.PosX == moveFrom.PosX - 1) || (moveTo.PosX == moveFrom.PosX + 1))) && !figDic[moveFrom.ToString()].IsWhite)
                {
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
                }
                return false;
            }
            catch (KeyNotFoundException)
            {
                
                if ((moveTo.PosY == moveFrom.PosY + 1 || (moveFrom.PosY == 2 && moveTo.PosY == moveFrom.PosY + 2)) && figDic[moveFrom.ToString()].IsWhite)
                {
                    try
                    {
                        var tmp = figDic[new Position { PosY = 3, PosX = moveFrom.PosX}.ToString()];

                        return false;
                    }
                    catch (KeyNotFoundException)
                    {

                    }
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
                }
                if ((moveTo.PosY == moveFrom.PosY - 1 || (moveFrom.PosY == 7 && moveTo.PosY == moveFrom.PosY - 2)) && !figDic[moveFrom.ToString()].IsWhite)
                {
                    try
                    {
                        var tmp = figDic[new Position { PosY = 6, PosX = moveFrom.PosX }.ToString()];
                        return false;
                    }
                    catch (KeyNotFoundException){}
                    figDic[moveTo.ToString()] = figDic[moveFrom.ToString()];
                    figDic.Remove(moveFrom.ToString());
                    return true;
                }

                return false;

            }
        }
    }
}
