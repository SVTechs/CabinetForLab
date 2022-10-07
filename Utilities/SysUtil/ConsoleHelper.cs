using System;

namespace Utilities.SysUtil
{
    public static class ConsoleHelper
    {
        public static void OutputLine(string message)
        {
            Console.WriteLine($"{message} ({DateTime.Now.ToStdString()})");
        }
    }
}
