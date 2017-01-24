using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JunctionMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string arg in args)
            {
            }

            StreamReader reader = new StreamReader("SyncPathConfig.txt");
            string line;
            List<string> paths = new List<string>();
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine(); 
                if (!string.IsNullOrEmpty(line))
                    paths.Add(line);
                
            }

            JunctionMaker maker = new JunctionMaker();
            maker.SyncDirectories = paths.ToArray();
            maker.Run();
        }

        static void PrintHelp()
        {

        }
    }
}
