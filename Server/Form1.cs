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
namespace Server
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        static string clientAdress = "";

        public Form1()
        {
            InitializeComponent();
            server = new SimpleTcpServer("127.0.0.1", 9001);
            server.Events.ClientConnected += ClientConnected;
            server.Events.ClientDisconnected += ClientDisconnected;
            server.Events.DataReceived += DataReceived;
            server.Start();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            String output2 = "";
            int key = 56;
            foreach (char ch in text)
            {
                output2 += (char)((ch + (128 - key)) % 128);
            }
            textBox2.Text = output2;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        void ClientConnected(object sender, ClientConnectedEventArgs e)
        {
            clientAdress = e.IpPort;
            Console.WriteLine("client connected");
        }
        void ClientDisconnected(object sender, ClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Client disconnected");
        }
        void DataReceived(object sender, DataReceivedEventArgs e)
        {
            textBox1.Invoke((MethodInvoker)(() =>
            {
                textBox1.Text += (Encoding.UTF8.GetString(e.Data));
            }));
        }

    }
}
