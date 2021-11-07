using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleTcp;
namespace ClientServerEncryptDecrypt
{
    public partial class Form1 : Form
    {
        SimpleTcpClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SimpleTcpClient("127.0.0.1", 9001);
            client.Events.Connected += Connected;
            client.Events.Disconnected += Disconnected;
            client.Events.DataReceived += DataReceived;
            client.Connect();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void Connected(object sender, EventArgs e)
        {
            Console.WriteLine("Server connected");
        }
        void Disconnected(object sender, EventArgs e)
        {
            Console.WriteLine("Server disconnected");
        }
        void DataReceived(object sender, DataReceivedEventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            String output = "";
            String text = textBox1.Text;
            int key = 56;
            foreach (char ch in text)
            {
                output += (char)((ch + key) % 128);
            }
            Console.WriteLine("enc: " + output);
            String output2 = "";
            foreach (char ch in output)
            {
                output2 += (char)((ch + (128 - key)) % 128);
            }
            //Console.WriteLine("dec: " + output2);

            client.Send(output);
            textBox1.Text = "";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
