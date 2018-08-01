using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileThinger.Model
{
    class ChessPiece
    {
        Rank ranker;
        Side sides;
        XCoor xC;
        YCoor yC;
        public ChessPiece(Rank r, Side s, XCoor x, YCoor y)
        {
            this.ranker = r;
            this.sides = s;
            this.xC = x;
            this.yC = y;
        }

        public XCoor XC { get => xC; }
        public YCoor YC { get => yC; }
        public Side Sides { get => sides; }
        public Rank Ranker { get => ranker; }
    }
}
