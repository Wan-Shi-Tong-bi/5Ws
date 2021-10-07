using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    abstract class PlayFigure
    {
        public abstract bool IsWhite { get; set; }
        public abstract char Fig { get; }
        public abstract bool CanMove(Position moveFrom,Position moveTo, ref Dictionary<string, PlayFigure> figDic);
    }
}
