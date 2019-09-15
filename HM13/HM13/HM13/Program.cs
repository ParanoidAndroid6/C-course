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
            ILogWriter cLW = new ConsoleLogWriter();
            
            ILogWriter fLW = new FileLogWriter();

            List<ILogWriter> list = new List<ILogWriter>(2)
            {
                cLW,
                fLW
            };


            ILogWriter mLW = new MultipleLogWriter(list);

            
            Console.ReadKey();
        }
    }
}
