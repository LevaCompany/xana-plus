using System;

namespace xanac
{
    internal class Logger
    {
        public static void Error(ErrorCode code)
        {
            ushort uCode = (ushort)code;
            Error($"[CODE:{uCode}]: {code.GetString()}");
        }

        public static void Error(string errText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ERR: " + errText);
            Reset();
        }

        private static void Reset()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
