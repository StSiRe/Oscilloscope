using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IoT.SerialPort
{
    public class ArduinoPortShell
    {
        SerialPortShell shell;
        public ArduinoPortShell(string comName)
        {
            shell = new SerialPort.SerialPortShell();

            shell.InitPort(comName, 9600);
            shell.Open();
            Thread.Sleep(500);
            Console.WriteLine("Serial port open");
            Connect();
            Console.WriteLine("Connected");
        }
        public void Connect()
        {
            bool result = false;
            while (true)
            {
                Task connectTask = Task.Run(() =>
                {
                    shell.Send("Connect" + "|");
                    Thread.Sleep(50);
                    string tmp = shell.ReadLine();
                    if (tmp.Contains(":Success"))
                    {
                        result = true;
                    }
                });
                connectTask.Wait(500);
                if (result)
                    return;
            }
        }
        public void SendMessage(string message, int waitTime = 100)
        {
            Thread.Sleep(waitTime);
            shell.Send(message + "|");
            Thread.Sleep(waitTime);
        }
        public string ReadMessage(int waitTime = 100)
        {
            Thread.Sleep(waitTime);
            string result = shell.ReadLine();
            return result;
        }
        public void Disconnect()
        {
            shell.Close();
        }
        public bool CheckAnswer()
        {
            string result = shell.ReadLine();
            if (result.Contains(":Success"))
            {
                return true;
            }
            return false;
        }

        public delegate void error();//Fucking shit
        public event error Error = delegate { };

        public bool IsRun = true;
        public void SysControl()
        {
            Task control = Task.Run(() =>
            {
                while (IsRun && CheckConnect())
                {
                    Thread.Sleep(500);
                }
                PortException.AddException("No connection!!!");
                Error();//Check!!@@
            });
        }
        /// <summary>
        /// Спрашивает у контроллера,все ли нормально
        /// </summary>
        /// <returns></returns>
        public bool CheckConnect()
        {
            SendMessage("C?", 25);
            string res = ReadMessage(25);
            if (res == true.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
