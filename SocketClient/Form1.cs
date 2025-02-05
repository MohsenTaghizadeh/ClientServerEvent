using LabBrabender.ClientSocket;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClient
{
    public partial class Form1: Form
    {
        Client client;
        public Form1()
        {

            InitializeComponent();
        }

        public void SOnRead(object sender, string ReciveText)
        {
            MessageBox.Show("Read:\n" + ReciveText);
        }
      
        public void SOnConnectionStatus(object sender, ConnectionStatus connectionStatus)
        {
            if (connectionStatus == ConnectionStatus.Connected)
            {
                Btn_Connect.Text = "Disconnect";
                Btn_Connect.ForeColor = Color.Red;
            }
            else if (connectionStatus == ConnectionStatus.Disconnect)
            {
                Btn_Connect.Text = "Connect";

                Btn_Connect.ForeColor = Color.Green;
            }
        }
        public void SOnError(object sender, string txt)
        {
           // MessageBox.Show("Error:\n" + txt);
        }
        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            if(Btn_Connect.Text == "Connect")
            {

                client = new Client(int.Parse(Txt_Port.Text), Txt_IP.Text);
                client.OnRead += SOnRead;
                client.OnChangeConnection += SOnConnectionStatus;
                client.OnError += SOnError;

                client.Connect();
            }
            else
            {
                client.Disconnect();
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            client.Send(txt_Send.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
