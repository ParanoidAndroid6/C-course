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
            
            var fileLogWriter = FileLogWriter.GetFileWriter();
            
            var multipleLogWriter = new MultipleLogWriter(consoleLogWriter, fileLogWriter);
            
            multipleLogWriter.LogError("Error!");
            multipleLogWriter.LogInfo("Info!!!");
            multipleLogWriter.LogWarning("Warning you!!!");

            Console.ReadKey();
        }
    }
}
