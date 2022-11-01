namespace xanac
{
    internal enum ErrorCode
    {
        NoArgs = 0,
        WrongEx = 1,
        NoExists = 2
    }

    internal static class ErrorCodeMethods
    {
        public static string GetString(this ErrorCode code)
        {
            switch (code)
            {
                case ErrorCode.NoArgs:
                    return "Нет аргументов";
                case ErrorCode.WrongEx:
                    return "Не верное расширение файла.";
                case ErrorCode.NoExists:
                    return "Файл не существует";
            }

            return "";
        }
    }
}
