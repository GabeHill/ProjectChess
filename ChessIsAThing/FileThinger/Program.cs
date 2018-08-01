using FileThinger.View;
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
            FileReader.ChessFileReader(args[0]);
        }

    }
}
