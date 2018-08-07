using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileThinger.Model {
    public class Enums {
        public enum Rank {
            King = 'K',
            Queen = 'Q',
            Bishop = 'B',
            Knight = 'N',
            Rook = 'R',
            Pawn = 'P'
        }

        public static string getRankName(Rank r) {
            string rank;
            switch(r) {
                case Enums.Rank.King:
                    rank="King";
                    break;
                case Enums.Rank.Queen:
                    rank="Queen";
                    break;
                case Enums.Rank.Bishop:
                    rank="Bishop";
                    break;
                case Enums.Rank.Knight:
                    rank="Knight";
                    break;
                case Enums.Rank.Rook:
                    rank="Rook";
                    break;
                case Enums.Rank.Pawn:
                    rank="Pawn";
                    break;
                default:
                    rank="None";
                    break;
            }
            return rank;
        }

        public enum Side {
            light = 'l',
            dark = 'd'
        }

        public static string getSideName(Side s) {
            if(s==Side.light)
                return "Light";
            else
                return "Dark";
        }

        public enum XCoor {
            A = 'a',
            B = 'b',
            C = 'c',
            D = 'd',
            E = 'e',
            F = 'f',
            G = 'g',
            H = 'h'
        }
        public enum YCoor {
            One = 1,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight
        }
    }
}
