using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace JunctionMaker
{
    public class JunctionMaker
    {
        private readonly string m_destinationPath = @"C:\UnifiedJunctionDataCollection\";
        private readonly string m_datacollectionPath = @"DataCollection\";
        private string[] m_syncDirectories = { @"Video\Episodes\", @"Video\Movies\" };

        public string[] SyncDirectories
        {
            get { return m_syncDirectories; }
            set { m_syncDirectories = value; }
        } 

        public void Run()
        {
            string[] drives = System.IO.Directory.GetLogicalDrives();
            List<string> harddisks = new List<string>(); 
            foreach (string str in drives)
            {
                DriveType drv = WinAPIWrapper.GetDriveType(str);
                if (drv == DriveType.Fixed)
                {
                    harddisks.Add(str);
                }
            }
            string destinationpath; 
            string sourcepath; 
            
            foreach (string drive in harddisks)
            {
                foreach (string directory in m_syncDirectories)
                {
                    try
                    {
                        string[] directories = System.IO.Directory.GetDirectories(String.Format("{0}{1}{2}", drive, m_datacollectionPath, directory));
                        foreach (string subjectdirectory in directories)
                        {
                            DirectoryInfo dinfo = new DirectoryInfo(subjectdirectory); 
                           
                            destinationpath = String.Format("{0}{1}{2}", m_destinationPath, directory, dinfo.Name);
                            sourcepath = subjectdirectory;

                            if (!JunctionPoint.Exists(destinationpath))
                            {
                                JunctionPoint.Create(destinationpath, sourcepath, false);
                                Console.WriteLine("Created junction from {0}", sourcepath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not complete linkage of directory {0}{1}{2}", drive, m_datacollectionPath, directory);
                    }
                }
            }

        }
    }
}
