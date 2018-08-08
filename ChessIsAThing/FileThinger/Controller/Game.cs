using FileThinger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileThinger.Controller
{
    class Game
    {
        public void PlayGame()
        {
            List<ChessPiece> p1 = GenerateSide(Side.light);
            List<ChessPiece> p2 = GenerateSide(Side.dark);
            DisplayBoard(p1, p2);
        }

        public void DisplayBoard(List<ChessPiece> p1, List<ChessPiece> p2)
        {
            char[,] board = new char[8, 8];
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (row % 2 == 0)
                    {
                        if (col % 2 == 0)
                        {
                            board[row, col] = '▒';
                            Console.Write('▒');
                        }
                        else
                        {
                            board[row, col] = '█';
                            Console.Write('█');
                        }
                    }
                    else
                    {
                        if (col % 2 == 0)
                        {
                            board[row, col] = '█';
                            Console.Write('█');
                        }
                        else
                        {
                            board[row, col] = '▒';
                            Console.Write('▒');
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine(board);
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
                    pieces.Add(new ChessPiece(Rank.Knight, Side.light, XCoor.B, YCoor.One));
                    pieces.Add(new ChessPiece(Rank.Knight, Side.light, XCoor.G, YCoor.One));
                    pieces.Add(new ChessPiece(Rank.Bishop, Side.light, XCoor.C, YCoor.One));
                    pieces.Add(new ChessPiece(Rank.Bishop, Side.light, XCoor.F, YCoor.One));
                    pieces.Add(new ChessPiece(Rank.King, Side.light, XCoor.E, YCoor.One));
                    pieces.Add(new ChessPiece(Rank.Queen, Side.light, XCoor.D, YCoor.One));
                    break;
                case Side.dark:
                    for (int i = 0; i < 8; i++)
                    {
                        pieces.Add(new ChessPiece(Rank.Pawn, Side.dark, (XCoor)i + 97, YCoor.Seven));
                    }
                    pieces.Add(new ChessPiece(Rank.Rook, Side.dark, XCoor.A, YCoor.Eight));
                    pieces.Add(new ChessPiece(Rank.Rook, Side.dark, XCoor.H, YCoor.Eight));
                    pieces.Add(new ChessPiece(Rank.Knight, Side.dark, XCoor.B, YCoor.Eight));
                    pieces.Add(new ChessPiece(Rank.Knight, Side.dark, XCoor.G, YCoor.Eight));
                    pieces.Add(new ChessPiece(Rank.Bishop, Side.dark, XCoor.C, YCoor.Eight));
                    pieces.Add(new ChessPiece(Rank.Bishop, Side.dark, XCoor.F, YCoor.Eight));
                    pieces.Add(new ChessPiece(Rank.King, Side.dark, XCoor.E, YCoor.Eight));
                    pieces.Add(new ChessPiece(Rank.Queen, Side.dark, XCoor.D, YCoor.Eight));
                    break;
                default:
                    break;
            }
            return pieces;
        }
    }
}
