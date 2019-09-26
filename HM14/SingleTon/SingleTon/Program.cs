using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogWriter consoleLogWriter = ConsoleLogWriter.GetConsole();
            
            var fileLogWriter = FileLogWriter.GetFileWriter(@"D:\file.txt");

            var logs = new ILogWriter[2];
            logs[0] = consoleLogWriter;
            logs[1] = fileLogWriter;

            var multipleLogWriter = MultipleLogWriter.GetMultipleLog(logs);
            
            multipleLogWriter.LogError("Error!");
            multipleLogWriter.LogInfo("Info!!!");
            multipleLogWriter.LogWarning("Warning you!!!");

            Console.ReadKey();
        }
    }
}
