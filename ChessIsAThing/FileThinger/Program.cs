using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileThinger
{
    class Program
    {
        static void Main(string[] args)
        {
            ChessFileReader(args[0]);
        }
        public static void ChessFileReader(string filename)
        {
            String line;
            try
            {
                StreamReader st = new StreamReader(filename);

                line = st.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = st.ReadLine();
                }
                st.Close();
                Console.ReadLine();
            }catch(Exception e)
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
