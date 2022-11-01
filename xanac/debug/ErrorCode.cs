namespace xanac
{
    internal enum ErrorCode
    {
        NoArgs = 0,
        NoInput = 1,
        NoExists = 2,
        UnkArg = 3
    }

    internal static class ErrorCodeMethods
    {
        public static string GetString(this ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.NoArgs:
                    return "Нет аргументов";
                case ErrorCode.NoInput:
                    return "Вы не указали файл на вход";
                case ErrorCode.NoExists:
                    return "Файл не существует";
                case ErrorCode.UnkArg:
                    return "Неизвестный аргумент";
            }

            return "";
        }
    }
}
