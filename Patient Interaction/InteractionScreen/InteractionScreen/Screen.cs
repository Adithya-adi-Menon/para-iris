using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace InteractionScreen
{
    public partial class Screen : Form
    {
        TcpListener newsock;
        TcpClient Client;
        NetworkStream ns;

        public Screen()
        {
            InitializeComponent();
            newsock = new TcpListener(3000);
            newsock.Start();
            byte[] data = new byte[1024];
            Client = newsock.AcceptTcpClient();
            ns = Client.GetStream();
        }

        public void sendSms(String str)
        {
            String flag1 = str +"\r\n";
            
            ns.Write(Encoding.ASCII.GetBytes(flag1), 0, flag1.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Shower");
            MessageBox.Show("Patient Selects Shower");  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Food");
            MessageBox.Show("Patient Selects Food");  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Water");
            MessageBox.Show("Patient Selects Water");  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Sleep");
            MessageBox.Show("Patient Selects Sleep");  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Walking");
            MessageBox.Show("Patient Selects Walking");  
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Music");
            MessageBox.Show("Patient Selects Music");  
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Movie");
            MessageBox.Show("Patient Selects Movie");  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sendSms("Patient Selects Toilet");
            MessageBox.Show("Patient Selects Toilet");  
        }

        private void Screen_Load(object sender, EventArgs e)
        {
        }
    }
}
