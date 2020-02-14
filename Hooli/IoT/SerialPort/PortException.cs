using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.SerialPort
{
    public class PortException
    {
        public static void AddException(string message)
        {
            Console.Out.WriteLine("Exception" + message);
        }
    }
}
