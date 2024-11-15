using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Un4SeenBASSInstallerNSISEdition
{
    internal class Program
    {
        public static void ExtractFiles(string nameSpace, string outDirectory, string internalFilePath, string resourceName)
        {
            //This is Very Important Code... DON'T CHANGE THIS!!! 

            Assembly assembly = Assembly.GetCallingAssembly();

            using (Stream s = assembly.GetManifestResourceStream(nameSpace + "." + (internalFilePath == "" ? "" : internalFilePath + ".") + resourceName))
            using (BinaryReader r = new BinaryReader(s))
            using (FileStream fs = new FileStream(outDirectory + "\\" + resourceName, FileMode.OpenOrCreate))
            using (BinaryWriter w = new BinaryWriter(fs))
                w.Write(r.ReadBytes((int)s.Length));
        }
        static void Main(string[] args)
        {
            Console.Title = "Un4SeenBASSInstallerNSISEdition by RiritoXXL"
            if(Directory.Exists("C:\\Program Files (x86)\\NSIS\\Plugins\\x86-unicode"))
            {
                ExtractFiles("Un4SeenBASSInstallerNSISEdition", "C:\\Program Files (x86)\\NSIS\\Plugins\\x86-unicode", "Resources", "bass.dll");
                if(Directory.Exists("C:\\Program Files (x86)\\NSIS\\Plugins\\x86-ansi"))
                {
                    ExtractFiles("Un4SeenBASSInstallerNSISEdition", "C:\\Program Files (x86)\\NSIS\\Plugins\\x86-ansi", "Resources", "bass.dll");
                }
                else
                {
                    Console.WriteLine("This Directory is not Exists... Pls Try Install NSIS!!!");
                    Environment.Exit(0);
                }
                Console.Write("Extracted Successfully to NSIS Folder!!! This Program is Created by RiritoXXL...");
                Environment.Exit(112);
            }
            else
            {
                Console.WriteLine("NSIS Is not Installed!!!");
            }
        }
    }
}
