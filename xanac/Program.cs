using System;
using System.IO;

namespace xanac
{
    internal class Program
    {
        private const string VERSION = "0.1";
        private const string EXT = ".x";

        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (CheckArg(arg))
                        return;
                }
            }

            Logger.Error(ErrorCode.NoInput);
        }

        private static bool CheckArg(string argument)
        {
            if (argument.StartsWith("-"))
            {
                switch (argument)
                {
                    case "--no-warn":
                        Logger.SetNoWarnings(true);
                        return false;

                    case "-h":
                    case "--help":
                        ShowHelp();
                        return true;

                    case "-v":
                    case "--version":
                        Console.WriteLine("Xana-X v" + VERSION);
                        return true;
                }
            }

            if (argument.EndsWith(EXT))
            {
                if (!File.Exists(argument))
                {
                    Logger.Error(ErrorCode.NoExists);
                    return true;
                }

                Logger.SetFileName(argument);

                RunScript(File.ReadAllLines(argument));
                return true;
            }

            Logger.Error(ErrorCode.UnkArg, argument);
            return true;
        }

        private static void RunScript(string[] codeLines)
        {
            foreach (string line in codeLines)
                Console.WriteLine(line);
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Использование: xanac [args..] [название файла]" + EXT);
            Console.WriteLine("Аргументы:");
            Console.WriteLine("  -h         Показать помощь Xana+");
            Console.WriteLine("  --help     Показать помощь Xana+");
            Console.WriteLine("  -v         Показать версию Xana+");
            Console.WriteLine("  --version  Показать версию Xana+");
            Console.WriteLine("  --no-warn  Отключить предупреждения");
        }
    }
}
