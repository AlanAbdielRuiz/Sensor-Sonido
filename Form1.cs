using System;
using System.IO.Ports;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensor_Sonido
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        
        PictureBox[] leds;
        public Form1()
        {
            InitializeComponent();
            serialPort = new SerialPort("COM4",9600);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            
            leds = new PictureBox[] { pictureBox1,
            pictureBox2,
            pictureBox3,
            pictureBox4,
            pictureBox5,
            pictureBox6,
            pictureBox7,
            pictureBox8,
            pictureBox9,
            pictureBox10,
            pictureBox11};
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!serialPort.IsOpen) 
            {
                serialPort.Open();
            }
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            this.Invoke(new Action(() => UpdateLEDs(data)));
        }
        private void UpdateLEDs(string data)
        {
            for (int i=0;i<leds.Length; i++)
            {
                leds[i].BackColor = data[i] == '1' ? Color.Black : Color.Red;
            }
        }
       

    }
}


