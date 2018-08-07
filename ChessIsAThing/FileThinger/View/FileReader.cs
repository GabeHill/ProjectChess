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
                DisplayBoard();
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
        public static void DisplayBoard()
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


    }
}
