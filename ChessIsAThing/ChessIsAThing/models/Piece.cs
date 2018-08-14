using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessIsAThing.models {

    public enum Side {
        White, Black
    }

    public enum Type {
        Pawn, Queen, King, Bishop, Knight, Rook
    }

    public abstract class Piece {
        public Side side { get; }
        public bool MoveX { get; }
        public bool MoveY { get; }
        public bool MoveDiagonal { get; }
        public bool SpecialCase { get; }

        public Piece(Type t,Side s) {
            side=s;
            switch(t) {
                case Type.Pawn:
                    MoveX=true;
                    MoveY=false;
                    MoveDiagonal=false; SpecialCase=true;
                    break;
                case Type.Queen:
                    MoveX=true;
                    MoveY=true;
                    MoveDiagonal=true;
                    SpecialCase=false;
                    break;
                case Type.King:
                    MoveX=true;
                    MoveY=true;
                    MoveDiagonal=true;
                    SpecialCase=true;
                    break;
                case Type.Bishop:
                    MoveX=false;
                    MoveY=false;
                    MoveDiagonal=true;
                    SpecialCase=false;
                    break;
                case Type.Knight:
                    MoveX=false;
                    MoveY=false;
                    MoveDiagonal=false;
                    SpecialCase=true;
                    break;
                case Type.Rook:
                    MoveX=true;
                    MoveY=true;
                    MoveDiagonal=false;
                    SpecialCase=false;
                    break;
                default:
                    MoveX=false;
                    MoveY=false;
                    MoveDiagonal=false;
                    SpecialCase=false;
                    break;
            }

        }

        
    }

    public class Knight : Piece {
        public Knight(Side s) : base(Type.Knight,s) { }
    }

    public class King : Piece {
        public King(Side s) : base(Type.King,s) { }
    }
    public class Queen : Piece {
        public Queen(Side s) : base(Type.Queen,s) { }
    }
    public class Pawn : Piece {
        public Pawn(Side s) : base(Type.Pawn,s) { }
    }
    public class Bishop : Piece {
        public Bishop(Side s) : base(Type.Bishop,s) { }
    }
}
