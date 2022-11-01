using System;

namespace xanac
{
    internal class Logger
    {
        private static string s_fileName;
        private static bool s_noWarnings = false;

        public static void SetFileName(string name)
        {
            s_fileName = name;
        }

        public static void SetNoWarnings(bool val)
        {
            s_noWarnings = val;
        }

        public static void Error(ErrorCode code,
                                 string info = null,
                                 int line = -1)
        {
            ushort uCode = (ushort)code;

            if (info != null)
                Error($"{code.GetString()}: {info} ({uCode})", line);
            else
                Error($"{code.GetString()} ({uCode})", line);
        }

        public static void Error(string errText, int line = -1)
        {
            if (s_fileName != null)
                Console.Write($"{s_fileName}:{line} ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("error: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(errText);
        }
    }
}
