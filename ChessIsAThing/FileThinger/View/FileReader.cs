using FileThinger.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileThinger.View
{
    class FileReader
    {
        public static void ChessFileReader(string filename)
        {
            List<ChessPiece> baseBoard = GenerateSide(Side.light);
            List<ChessPiece> baseBoard2 = GenerateSide(Side.dark);
            List<ChessPiece> p1 = new List<ChessPiece>();
            String line;
            try
            {
                StreamReader st = new StreamReader(filename);
                string rank = "";
                string side = "";
                string Xcoor = "";
                int Ycoor = 0;
                Rank r;
                Side s;
                XCoor x;
                YCoor y;

                line = st.ReadLine();

                while (line != null)
                {
                    if (line.Count() == 4)
                    {
                        char[] coordinates = line.ToCharArray();
                        r = (Rank)coordinates[0];
                        s = (Side)coordinates[1];
                        x = (XCoor)coordinates[2];
                        y = (YCoor)coordinates[3];
                        p1.Add(new ChessPiece(r, s, x, y));
                        switch (r)
                        {
                            case Rank.King:
                                rank = "King";
                                break;
                            case Rank.Queen:
                                rank = "Queen";
                                break;
                            case Rank.Bishop:
                                rank = "Bishop";
                                break;
                            case Rank.Knight:
                                rank = "Knight";
                                break;
                            case Rank.Rook:
                                rank = "Rook";
                                break;
                            case Rank.Pawn:
                                rank = "Pawn";
                                break;
                            default:
                                break;
                        }
                        switch (s)
                        {
                            case Side.light:
                                side = "Light";
                                break;
                            case Side.dark:
                                side = "Dark";
                                break;
                            default:
                                break;
                        }
                        switch (x)
                        {
                            case XCoor.A:
                                Xcoor = "A";
                                break;
                            case XCoor.B:
                                Xcoor = "B";
                                break;
                            case XCoor.C:
                                Xcoor = "C";
                                break;
                            case XCoor.D:
                                Xcoor = "D";
                                break;
                            case XCoor.E:
                                Xcoor = "E";
                                break;
                            case XCoor.F:
                                Xcoor = "F";
                                break;
                            case XCoor.G:
                                Xcoor = "G";
                                break;
                            case XCoor.H:
                                Xcoor = "H";
                                break;
                            default:
                                break;
                        }
                        Ycoor = (int)y - 48;

                        //TODO Code to compare here!

                        Console.WriteLine($"Moved {side} {rank} to {Xcoor}{Ycoor}.");
                        line = st.ReadLine();
                    }
                    else

                        line = st.ReadLine();
                }
                st.Close();
                Console.ReadLine();
                DisplayBoard(baseBoard, baseBoard2);
                MovePieces(p1, baseBoard, baseBoard2);
                Console.WriteLine("");
                DisplayBoard(baseBoard, baseBoard2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e);
            }
            finally
            {
                Console.WriteLine("Excecuting finally");
            }
        }

        private static void MovePieces(List<ChessPiece> p1, List<ChessPiece> lightS, List<ChessPiece> darkS)
        {
            foreach(ChessPiece p in p1)
            {
                if (p.Sides == Side.light)
                {
                    foreach(ChessPiece l in lightS)
                    {
                        if(l.Ranker == p.Ranker)
                        {
                            l.XC = p.XC;
                            l.YC = p.YC;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (ChessPiece l in darkS)
                    {
                        if (l.Ranker == p.Ranker)
                        {
                            l.XC = p.XC;
                            l.YC = p.YC;
                            break;
                        }
                    }
                }
            }
        }

        public static void DisplayBoard(List<ChessPiece> p1, List<ChessPiece> p2)
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
                        }
                        else
                        {
                            board[row, col] = '█';
                        }
                    }
                    else
                    {
                        if (col % 2 == 0)
                        {
                            board[row, col] = '█';
                        }
                        else
                        {
                            board[row, col] = '▒';
                        }
                    }
                }
            }
            foreach (ChessPiece i in p1)
            {
                AddPiece(board, i);
            }
            foreach (ChessPiece i in p2)
            {
                AddPiece(board, i);
            }

            PrintBoard(board);

        }

        private static void AddPiece(char[,] board, ChessPiece i)
        {
            int xCoorBoy = ConvertXToInt(i.XC) - 1;
            int yCoorBoy = (int)i.YC - 49;
            board[xCoorBoy, yCoorBoy] = ConvertRankToChar(i.Ranker, i.Sides);
        }

        public static void PrintBoard(char[,] board)
        {
            int count = 1;
            foreach (char p in board)
            {
                Console.Write(p);
                if (count == 8)
                {
                    Console.WriteLine("");
                    count = 0;
                }
                count++;
            }
        }

        public static int ConvertXToInt(XCoor xCoor)
        {
            switch (xCoor)
            {
                case XCoor.A:
                    return 1;
                    break;
                case XCoor.B:
                    return 2;
                    break;
                case XCoor.C:
                    return 3;
                    break;
                case XCoor.D:
                    return 4;
                    break;
                case XCoor.E:
                    return 5;
                    break;
                case XCoor.F:
                    return 6;
                    break;
                case XCoor.G:
                    return 7;
                    break;
                case XCoor.H:
                    return 8;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public static List<ChessPiece> GenerateSide(Side s)
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

        public static char ConvertRankToChar(Rank r, Side s)
        {
            switch (r)
            {
                case Rank.King:
                    if (s == Side.light)
                    {
                        return 'K';
                    }
                    else
                        return 'k';
                    break;
                case Rank.Queen:
                    if (s == Side.light)
                    {
                        return 'Q';
                    }
                    else
                        return 'q';
                    break;
                case Rank.Bishop:
                    if (s == Side.light)
                    {
                        return 'B';
                    }
                    else
                        return 'b';
                    break;
                case Rank.Knight:
                    if (s == Side.light)
                    {
                        return 'N';
                    }
                    else
                        return 'n';
                    break;
                case Rank.Rook:
                    if (s == Side.light)
                    {
                        return 'R';
                    }
                    else
                        return 'r';
                    break;
                case Rank.Pawn:
                    if (s == Side.light)
                    {
                        return 'P';
                    }
                    else
                        return 'p';
                    break;
                default:
                    return 'N';
                    break;
            }
        }

    }
}
