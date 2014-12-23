using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Runtime.InteropServices;

namespace Curry_Client
{

    public partial class Form1 : Form
    {
        private String ServerIP;
        private static byte[] receivedpacket;
        private static byte[] logincode;
        private int currentXP;
        private bool super = false;
        private const int port = 32320;
        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.
        private static String response = String.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        /*
        public void textWriteLine(String t)
        {
            String[] oldAr = {};
            if (richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new MethodInvoker(delegate { oldAr = richTextBox1.Lines; }));
            }
            else
            {
                oldAr = richTextBox1.Lines;
            }

            if(oldAr.Length > 0){
                String[] newAr = new String[oldAr.Length + 1];
                for (int i = 0; i < oldAr.Length; i++)
                    newAr[i + 1] = oldAr[i];

                newAr[0] = t;
                if (richTextBox1.InvokeRequired)
                {
                    richTextBox1.Invoke(new MethodInvoker(delegate { richTextBox1.Lines = newAr; }));
                }
                else
                {
                    richTextBox1.Lines = newAr;
                }
            }
        }
         */
        TabPage prevtab;
        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
            Console.WriteLine("Client Launch");
            //connect("127.0.0.1");
            prevtab = tabControl1.SelectedTab;
            logincode = new byte[3];
            ServerIP = "127.0.0.1";
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void requestXP()
        {
            byte[] packet = new byte[9];
            //packet type 2 is an XP request/transmission protocol
            //packet bytes 1-3 are authorization bytes
            packet[0] = 2;
            packet[1] = logincode[0];
            packet[2] = logincode[1];
            packet[3] = logincode[2];
            Console.WriteLine("Verification code: " + Convert.ToInt32(logincode[0]) + Convert.ToInt32(logincode[1]) + Convert.ToInt32(logincode[2]));
            byte[] temp = Encoding.ASCII.GetBytes("<EOF>");
            temp.CopyTo(packet, 4);
            connect(ServerIP, packet);
        }

        //IP_AD is the IP address of the server
        private static void connect(string IP_AD, byte[] data)
        {
            try
            {
                //init
                IPAddress ipAddress = IPAddress.Parse(IP_AD);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                //Connect through the remote socket (endpoint)
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);

                // Send test data to the remote device.
                SendBytes(client, data);
                sendDone.WaitOne();

                // Receive the response from the remote device.
                Receive(client);
                receiveDone.WaitOne();

                // Write the response to the console.
                Console.WriteLine("Response received : " + response);

                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete the connection.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to " + client.RemoteEndPoint.ToString());

                // Signal that the connection has been made.
                connectDone.Set();
            }
            catch (Exception e)
            {
                String p = e.ToString();
                Console.WriteLine(p);
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Create the state object.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket 
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Read data from the remote device.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                    // Get the rest of the data.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // All the data has arrived; put it in response.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                        receivedpacket = state.buffer;
                        Console.WriteLine("Response: " + response);
                        if (receivedpacket[0] == 2)
                        {
                            //Experience Point transmission protocol
                            if (receivedpacket[1] == 1 && receivedpacket[2] == logincode[0] && receivedpacket[3] == logincode[1] && receivedpacket[4] == logincode[2])
                            {
                                //Verified the server and the server accepted the packet
                                String[] items = response.Split('\0');
                                int finalxp = Convert.ToInt32(items[1]);
                                Console.WriteLine("XP Received: " + finalxp);
                            }
                        }
                    }
                    // Signal that all bytes have been received.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendBytes(Socket client, byte[] byteData)
        {

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent " + bytesSent + " bytes to server.");

                // Signal that all bytes have been sent.
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // State object for receiving data from remote device.
        public class StateObject
        {
            // Client socket.
            public Socket workSocket = null;
            // Size of receive buffer.
            public const int BufferSize = 256;
            // Receive buffer.
            public byte[] buffer = new byte[BufferSize];
            // Received data string.
            public StringBuilder sb = new StringBuilder();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            loginform lg = new loginform(this);
            lg.ShowDialog();
        }


        public byte[] login
        {
            get { return logincode; }
            set { logincode = value; }
        }

        public String serverIP
        {
            get { return ServerIP; }
            set { serverIP = value; }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //connect("108.248.159.5");
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {

        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(192, 64, 0);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(255, 100, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            enableSuperUser();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Super User")//your specific tabname
            {
                tabControl1.SelectedTab = prevtab;
                FormSuperUser lg = new FormSuperUser();
                lg.ShowDialog();
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab.Text != "Super User")
                {
                    prevtab = tabControl1.SelectedTab;
                }
            }
            catch(Exception g)
            {
                Console.WriteLine(g.ToString());
            }
        }
        private void enableSuperUser()
        {
            super = true;
            bool flag = false;
            foreach (TabPage t in tabControl1.TabPages)
            {
                if (t.Text == "Super User")
                {
                    flag = true;
                }
            }
            if (!flag)
            {
                tabControl1.TabPages.Add(new TabPage().Text = "Super User");
            }
        }
        private void disableSuperUser()
        {
            super = false;
            foreach (TabPage t in tabControl1.TabPages)
            {
                if (t.Text == "Super User")
                {
                    tabControl1.TabPages.Remove(t);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disableSuperUser();
        }

        private void button_xp_Click(object sender, EventArgs e)
        {
            requestXP();
        }
    }
}
