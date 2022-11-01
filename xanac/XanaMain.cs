using System;
using System.IO;

namespace xanac
{
    internal class XanaMain
    {
        private const string VERSION = "0.1";
        private const string EX = ".x";

        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string filePath = args[0];

                if (filePath.EndsWith(EX))
                {
                    if (!File.Exists(filePath))
                    {
                        Logger.Error(ErrorCode.NoExists);
                        ShowUsage();
                        return;
                    }

                    RunScript(File.ReadAllLines(filePath));
                    return;
                }

                Logger.Error(ErrorCode.WrongEx);
                ShowUsage();
                return;
            }

            Logger.Error(ErrorCode.NoArgs);
            ShowUsage();
        }

        private static void RunScript(string[] codeLines)
        {
            // ...
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Xana-X v" + VERSION);
            Console.WriteLine("Использование: ");
            Console.WriteLine("xanac [название файла].x");
            Console.ReadKey();
        }
    }
}
