using System.Collections.Generic;
using System.IO;

namespace JunctionMaker
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
