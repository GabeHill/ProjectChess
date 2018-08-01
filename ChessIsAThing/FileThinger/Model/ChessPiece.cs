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
        bool isDead = false;

        public ChessPiece(Rank r, Side s, XCoor x, YCoor y)
        {
            this.ranker = r;
            this.sides = s;
            this.xC = x;
            this.yC = y;
        }

        public List<ChessPiece> GenerateSide(Side s)
        {
            List<ChessPiece> pieces = new List<ChessPiece>();
            switch (s)
            {
                case Side.light:
                    for (int i = 0; i < 8; i++)
                    {
                        pieces.Add(new ChessPiece(Rank.Pawn, Side.light, (XCoor)i + 97, YCoor.Two));
                    }
                    pieces.Add(new ChessPiece(Rank.Rook, Side.light, XCoor.A, YCoor.One));
                    pieces.Add(new ChessPiece(Rank.Rook, Side.light, XCoor.H, YCoor.One));
                    
                    break;
                case Side.dark:
                    break;
                default:
                    break;
            }
            return pieces;
        }

        public XCoor XC { get => xC; }
        public YCoor YC { get => yC; }
        public Side Sides { get => sides; }
        public Rank Ranker { get => ranker; }
        public bool IsDead { get => isDead; set => isDead = value; }
    }
}
