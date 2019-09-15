using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HM13
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogWriter cLW = new ConsoleLogWriter();
            
            FileLogWriter fLW = new FileLogWriter();

            MultipleLogWriter mLW = new MultipleLogWriter(cLW, fLW);

            mLW.LogError("Error!");
            mLW.LogInfo("Information!");
            mLW.LogWarning("Warning!");

            Console.ReadKey();
        }
    }
}
