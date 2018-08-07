using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FileThinger.Model;

namespace FileThinger.View
{
    class FileReader
    {
        
        public static void ChessFileReader(string filename)
        {
            try
            {
                StreamReader st = new StreamReader(filename);
                
                Enums.Rank r;
                Enums.Side s;
                Enums.XCoor x;
                Enums.YCoor y;

               string line = st.ReadLine();

                while (line != null)
                {
                    if (line.Count() == 4)
                    {
                        char[] coordinates = line.ToCharArray();
                        r = (Enums.Rank)coordinates[0];
                        s = (Enums.Side)coordinates[1];
                        x =(Enums.XCoor) coordinates[2];
                        y = (Enums.YCoor)coordinates[3]-48;
                       
                        Console.WriteLine($"Moved {Enums.getSideName(s)} {Enums.getRankName(r)} to {x}{y}.");
                        line = st.ReadLine();
                    }
                    else
                        line = st.ReadLine();
                }
                st.Close();
                Console.ReadLine();
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
    }
}
