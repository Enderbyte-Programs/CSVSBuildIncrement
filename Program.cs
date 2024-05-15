using System;
using System.IO;

namespace VersionUpdate
{
    internal class main
    {
        public static void Main(string[] args)
        {
            string BaseLocation = args[0];

            string ASFile = BaseLocation + "\\Properties\\AssemblyInfo.cs";
            string InfoFile = BaseLocation + "\\build-info.txt";

            int buildno;
            if (!File.Exists(InfoFile))
            {
                buildno = 100;
                File.Create(InfoFile);
            }
            else
            {
                try
                {
                    buildno = int.Parse(File.ReadAllText(InfoFile));
                } catch
                {
                    buildno = 100;
                }

            }


            buildno++;


            string[] ASLines = File.ReadAllLines(ASFile);
            string newline = $"[assembly: AssemblyVersion(\"{buildno}.0.0.0\")]";
            ASLines[34] = newline;

            File.WriteAllLines(ASFile, ASLines);
            File.WriteAllText(InfoFile,buildno.ToString());
        }
    }
}