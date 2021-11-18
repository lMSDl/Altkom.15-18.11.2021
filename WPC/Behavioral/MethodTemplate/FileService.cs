using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPC.Behavioral.MethodTemplate
{
    public class FileService : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Close File.");
        }

        public void Write(string @string)
        {
            Console.WriteLine("Appending Log message to file : " + @string);
        }
    }
}