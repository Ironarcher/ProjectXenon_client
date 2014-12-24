﻿using System;
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
    public partial class FormSuperUser : Form
    {
        private static byte[] receivedpacket;
        private static byte[] logincode;
        private const int port = 32320;
        private String ServerIP = "127.0.0.1";
        private static String response = String.Empty;
        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        public Group selectedGroup;
        public List<Group> groupList = new List<Group>();
        public FormSuperUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMission f = new FormMission();
            f.Show();
        }

        private void FormSuperUser_Load(object sender, EventArgs e)
        {
            //listBox2.Items
            //GET USERS FROM SERVER
            //ADD TO LISTBOX 2
            //GET GROUPS MADE IN CURRICULUM
            //ADD THESE GROUPS TO GROUPLIST
            //ADD THE MEMBERS OF DIFFERENT GROUPS TO LISTBOX 1
            //Default Groups: All Users, All Superusers, 

        }

        private void sendStringPacket()
        {
            byte[] packet = new byte[60];
            //packet type 6 is a string array exchange for user control
            //packet bytes 1-3 are authorization bytes
            packet[0] = 6;
            packet[1] = logincode[0];
            packet[2] = logincode[1];
            packet[3] = logincode[2];
            Console.WriteLine("Verification code: " + Convert.ToInt32(logincode[0]) + Convert.ToInt32(logincode[1]) + Convert.ToInt32(logincode[2]));
            byte[] fnl = Encoding.ASCII.GetBytes("\0");
            fnl.CopyTo(packet, 4);
            //Insert string payload here:
            String[] arpayload = new String[1];
            arpayload[0] = "null";
            int arcount = 5;
            foreach (String s in arpayload)
            {
                if(s != null  || s != String.Empty){
                    byte[] tempa = Encoding.ASCII.GetBytes(s);
                    tempa.CopyTo(packet, arcount);
                    fnl.CopyTo(packet, tempa.Length + arcount + 1);
                    arcount += tempa.Length+2;
                }
            }
            byte[] tempb = Encoding.ASCII.GetBytes("<EOF>");
            tempb.CopyTo(packet, arcount);
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
                        if (receivedpacket[0] == 6)
                        {
                            //Experience Point transmission protocol
                            if (receivedpacket[1] == 1 && receivedpacket[2] == logincode[0] && receivedpacket[3] == logincode[1] && receivedpacket[4] == logincode[2])
                            {
                                //Verified the server and the server accepted the packet
                                String[] items = response.Split('\0');
                                //CHANGE NUMBER OF STRINGS TO END WITH
                                String[] finalresult = new String[3];
                                Console.WriteLine("SUCCESS");
                                for(int f = 0; f<3; f++)
                                {
                                    String s = items[f + 1];
                                    if (s != "<EOF>")
                                    {
                                        finalresult[f] = s;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                Console.WriteLine(items[1]);
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
            set { ServerIP = value; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Group Name")
            {
                bool flag = true;
                int i = 1;
                while (flag)
                {
                    bool flag2 = true;
                    for (int j = 0; j < groupList.Count; j++)
                    {
                        if (groupList[j].name == "NewGroup" + i)
                        {
                            flag2 = false;
                        }
                    }
                    if (flag2)
                    {
                        flag = false;
                    }
                    else
                    {
                        i++;
                    }
                }
                Group newg = new Group("NewGroup" + i);
                groupList.Add(newg);
                comboBox1.Items.Add(newg.name);
            }
            else
            {
                bool flag2 = true;
                for (int j = 0; j < groupList.Count; j++)
                {
                    if (groupList[j].name == textBox1.Text)
                    {
                        flag2 = false;
                    }

                }
                if (flag2)
                {
                    Group newg = new Group(textBox1.Text);
                    groupList.Add(newg);
                    comboBox1.Items.Add(newg.name);
                }
                else
                {
                    MessageBox.Show("Error: Group already made with given name");
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this group?", "Alert", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    String n = comboBox1.SelectedItem.ToString();
                    comboBox1.Items.Remove(comboBox1.SelectedItem);
                    for (int i = 0; i < groupList.Count; i++)
                    {
                        if (groupList[i].name == n)
                        {
                            groupList.Remove(groupList[i]);
                            updateListBox1();
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("No group selected", "Alert");
            }
        }
        public void updateListBox1()
        {
            if (comboBox1.SelectedItem == null && comboBox1.Items.Count != 0)
            {
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
            if (comboBox1.SelectedItem != null)
            {
                Group selectedG = null;
                for (int i = 0; i < groupList.Count; i++)
                {
                    if (groupList[i].name == comboBox1.SelectedItem.ToString())
                    {
                        selectedG = groupList[i];
                    }
                }
                if (selectedG != null)
                {
                    listBox1.Items.Clear();
                    for (int i = 0; i < selectedG.users.Count; i++)
                    {
                       // listBox1.Items.Add(User.getFirstName(selectedG.users[i]).ToString() + " " + User.getLastName(selectedG.users[i].ToString()));
                        //Above line adds users to the listbox
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            sendStringPacket();
        }
    }
    public class Group
    {
        public string name;
        public List<int> users = new List<int>();
        public Group(string n)
        {
            name = n;
        }
    }
}