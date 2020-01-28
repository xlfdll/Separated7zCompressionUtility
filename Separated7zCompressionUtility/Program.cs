using System;
using System.Diagnostics;
using System.IO;

namespace Separated7zCompressionUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Separated 7-Zip Compression Utility");
            Console.WriteLine("(C) 2019 Xlfdll Workstation");
            Console.WriteLine();

            if (args.Length > 0)
            {
                Boolean keepOriginal = (args.Length > 3 && args[2] == "/nodel");
                String command = @"C:\Program Files\7-Zip\7z.exe";
                String arguments = @"a -mx {del} ""{0}"" ""{1}""".Replace("{del}", keepOriginal ? String.Empty : "-sdel");

                foreach (String fileName in Directory.GetFiles(args[0], args[1], SearchOption.TopDirectoryOnly))
                {
                    String newFileName = Path.Combine(args[0], Path.GetFileNameWithoutExtension(fileName) + ".7z");
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(command, String.Format(arguments, newFileName, fileName))
                    {
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false
                    };

                    using (Process process = Process.Start(processStartInfo))
                    {
                        Console.WriteLine(process.StandardOutput.ReadToEnd());
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(process.StandardError.ReadToEnd());
                        Console.ResetColor();

                        process.WaitForExit();
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage:");
                Console.WriteLine();
                Console.WriteLine("Separated7zCompressionUtility [/nodel] <Directory> <Search Pattern>");
                Console.WriteLine();
                Console.WriteLine("<Directory> - The directory containing files to be compressed");
                Console.WriteLine("<Search Pattern> - The search pattern to pick specific files (for example, *.txt, *.*, etc.)");
                Console.WriteLine("/nodel - Do not delete original files (the default behavior is to delete all original files after compression)");
                Console.WriteLine();
            }
        }
    }
}