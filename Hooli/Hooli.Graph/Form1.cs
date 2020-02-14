using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IoT.SerialPort;
namespace Hooli.Graph
{
    public partial class Form1 : Form
    {
        SerialPortShell serial;
        public Form1()
        {
            InitializeComponent();
            serial = new SerialPortShell();
            AddPortsToBox();
        }
        private void AddPortsToBox()
        {
            BoxSerialPorts.Items.Clear();
            var ports = serial.GetAvailablePorts();
            foreach (var port in ports)
            {
                BoxSerialPorts.Items.Add(port);
            }
        }
        private void ButtonRefreshPorts_Click(object sender, EventArgs e)
        {
            AddPortsToBox();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                var port = BoxSerialPorts.Items[BoxSerialPorts.SelectedIndex];
                var speed = Convert.ToInt32(BoxPortSpeed.Text);
                serial.InitPort(port.ToString(), speed);
                if (!serial.Open())
                {
                    Console.Out.WriteLine("Hooli.IoT can`t connect to " + port.ToString());
                    MessageBox.Show("Hooli.IoT can`t connect to " + port.ToString());
                    return;
                }
                Console.Out.WriteLine("Serial port configurated and connected successful!");
                serial.OnDataEvent += Serial_OnDataEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Serial_OnDataEvent(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Console.Out.WriteLine();
        }
        private void ButtonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                serial.Close();
                serial.OnDataEvent -= Serial_OnDataEvent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
