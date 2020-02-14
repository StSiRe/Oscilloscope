using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
namespace IoT.PowerStation
{
    public class PowerStation
    {
        SerialPort.ArduinoPortShell arduino;
        public PowerStation(string comName)
        {
            arduino = new SerialPort.ArduinoPortShell(comName);
        }

        #region Power Station functions
        public void On()
        {
            arduino.SendMessage("On");
            arduino.CheckAnswer();
        }
        public void Off()
        {
            arduino.SendMessage("Off");
            arduino.CheckAnswer();
        }
        public void PWM(int channel, int duty)
        {
            if (channel > 0)
            {
                arduino.SendMessage("PWM" + channel);
            }
            else
            {
                arduino.SendMessage("PWM");
            }
            arduino.SendMessage(duty.ToString());

            arduino.CheckAnswer();
        }       
        public void IsWorkRequest()
        {
            arduino.SendMessage("GetPowerState");
            string result = arduino.ReadMessage();
            if (result.Contains("PowerState:"))
            {
                result = result.Substring(result.LastIndexOf(':') + 2);
                result = result.Substring(0, result.Length - 1);
            }
            Console.Out.WriteLine(result);
        }

        public int PowerState()
        {
            arduino.SendMessage("State");
            string result = arduino.ReadMessage();
            Console.WriteLine(result);
            if (result.Contains("On"))
            {
                Console.WriteLine("State : On");
                return 1;
            }
            if (result.Contains("Off"))
            {
                Console.WriteLine("State : Off");
                return 0;
            }
            return 0;
        }
        #endregion
    }
}
