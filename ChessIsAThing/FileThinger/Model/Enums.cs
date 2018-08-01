using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileThinger.Model

{
    public enum Rank
    {
        King = 'K',
        Queen = 'Q',
        Bishop = 'B',
        Knight = 'N',
        Rook = 'R',
        Pawn = 'P'
    }
    public enum Side
    {
        light = 'l',
        dark = 'd'
    }
    public enum XCoor
    {
        A = 'a',
        B = 'b',
        C = 'c',
        D = 'd',
        E = 'e',
        F = 'f',
        G = 'g',
        H = 'h'
    }
    public enum YCoor
    {
        One = '1',
        Two = '2',
        Three = '3',
        Four = '4',
        Five = '5',
        Six = '6',
        Seven = '7',
        Eight = '8'
    }

}
