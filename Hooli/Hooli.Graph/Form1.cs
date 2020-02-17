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
            DrawCoord();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Bitmap bmp;//Здесь рисуем
        void DrawValue(int x,int y)
        {

        }
        void DrawCoord()
        {
            bmp = new Bitmap(PicBox.ClientSize.Width, PicBox.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                //Draw ordinates
                g.DrawLine(Pens.Black, 15, 15, 15, PicBox.ClientSize.Height - 15);
                g.DrawLine(Pens.Black, 15, PicBox.ClientSize.Height - 15, PicBox.ClientSize.Width, PicBox.ClientSize.Height - 15);
                //------------
                //Draw ends of ordinates

                SolidBrush Brush = new SolidBrush(Color.Black);
                g.DrawString("0", Font, Brush, 5, PicBox.ClientSize.Height - 15);//Начало координат
                //------------------

            }
            PicBox.Image = bmp;
        }
        Pair ParseData(string data)
        {
            if (data[0] != '$') return new Pair(0,0);
            //$value value2;
            //data = data.Substring(1);
            data = data.Substring(1, data.Length - 2);//value value2
            var nData = data.Split(' ');// "value","value2" - in array
            if (nData.Length <= 1) return new Pair(0, 0);
            int x = Convert.ToInt16(nData[0]);
            int y = Convert.ToInt16(nData[1]);
            //Converting x,y to 8 bit value
            /// 1024 - value
            /// 256 - x
            /// x = 256*value/1024 = value/4
            return new Pair(x/4, y/4);
        }
    }
    class Pair
    {
        public int x { get; set; }
        public int y { get; set; }
        public Pair(int xi,int yi)
        {
            x = xi;
            y = yi;
        }
    }

}
