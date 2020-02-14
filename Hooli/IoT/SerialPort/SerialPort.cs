using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.SerialPort
{
    public class SerialPortShell
    {
        public System.IO.Ports.SerialPort serialPort;
        public bool InitPort(string name, int speed)
        {
            serialPort = new System.IO.Ports.SerialPort();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            string portName = "";
            foreach (var port in ports)
            {
                if (port == name)
                {
                    portName = port;
                }
            }
            #region Create Port object,and open serial port 
            try
            {
                serialPort = new System.IO.Ports.SerialPort(portName, speed);
                if (serialPort.IsOpen)
                {
                    throw new SystemException("Выбранный порт уже используется.Ошибка!");
                }
                AppDomain.CurrentDomain.ProcessExit += SerialProcessExit;
                return true;
            }
            catch (Exception e)
            {
                PortException.AddException(e.Message);
                return false;
            }
            #endregion

        }

        /// <summary>
        /// Выполняет закрытие порта,в случае закрытия процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialProcessExit(object sender, EventArgs e)
        {
            Console.Out.WriteLine("Closing serial port");
            bool result = Close();
            if (result)
            {
                Console.Out.WriteLine("Serial port successfully closed");
            }
            else
            {
                Console.Out.WriteLine("Serial port hasn`t was closed.Error");
            }
        }

        public bool Open()
        {
            try
            {
                serialPort.Open();
                return true;
            }
            catch (Exception e)
            {
                PortException.AddException(e.Message);
                return false;
            }
        }


        public bool SendLine(string message)
        {
            try
            {
                serialPort.WriteLine(message);
                return true;
            }
            catch (Exception e)
            {
                PortException.AddException(e.Message);
                return false;
            }
        }

        public string ReadLine()
        {
            try
            {
                return serialPort.ReadLine();
            }
            catch (Exception e)
            {
                PortException.AddException(e.Message);
                return "";
            }
        }
        public bool Send(string message)
        {
            try
            {
                serialPort.Write(message);
                return true;
            }
            catch (Exception e)
            {
                PortException.AddException(e.Message);
                return false;
            }
        }
        public bool Close()
        {
            if (!serialPort.IsOpen)
                return true;
            try
            {
                serialPort.Close();
                return true;
            }
            catch (Exception e)
            {
                PortException.AddException(e.Message);
                return false;
            }
        }

        public string[] GetAvailablePorts()
        {
            try
            {
                return System.IO.Ports.SerialPort.GetPortNames();
            }
            catch (Exception e)
            {
                PortException.AddException(e.Message);
                return null;
            }
        }
    }
}
