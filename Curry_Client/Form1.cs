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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Reflection;

namespace Curry_Client
{

    public partial class Form1 : Form
    {
        private String ServerIP;
        private static byte[] logincode;
        public static int currentXP, currentMana, currentGold, currentLevel;
        public static Form1 currentForm;
        public static bool super = false;
        private const int port = 32320;
        // ManualResetEvent instances signal completion.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // The response from the remote device.

        public Form1()
        {
            InitializeComponent();
            currentForm = this;
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
            level_plaque.Image = Curry_Client.Properties.Resources.plaque1;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void requestData(int indent)
        {
            byte[] packet = new byte[9];
            if (indent > 0 && indent < 256)
            {
                packet[0] = Convert.ToByte(indent);
            }
            else
            {
                Console.WriteLine("Packet Indentification overflow error!");
            }
            packet[1] = logincode[0];
            packet[2] = logincode[1];
            packet[3] = logincode[2];
            byte[] temp = Encoding.ASCII.GetBytes("<EOF>");
            temp.CopyTo(packet, 4);
            connect(ServerIP, packet);
        }

        public void requestXP()
        {
            requestData(2);
        }

        public void requestLevel()
        {
            requestData(3);
        }

        public void requestMinXP()
        {
            requestData(4);
        }

        public void requestMaxXP()
        {
            requestData(5);
        }

        private void getAvailableMissions()
        {
            requestData(15);
        }

        private void getFinishedMissions()
        {
            requestData(16);
        }

        private void getCurrentAvatar()
        {
            requestData(17);
        }

        private void setAvatarr()
        {
            
        }

        private void getLeaderboardData()
        {
            requestData(20);
        }

        private void getBadgesEarned()
        {
            requestData(19);
        }

        private void sendChatMsg(String message)
        {
            
        }

        private void getChatUpdate()
        {
            requestData(22);
        }

        private void getGold()
        {
            requestData(23);
        }

        private void getMana()
        {
            requestData(24);
        }

        private void getInv()
        {
            requestData(25);
        }

        private void startMission(int missionID)
        {
            //modify data packet with information to start sending questions over/starting a timer (requires MissionID)
        }

        private void eraseUserData()
        {
            requestData(7);
            this.login[0] = 0;
            this.login[1] = 0;
            this.login[2] = 0;
        }

        private void modifyPassword()
        {

        }

        private void verifyPassword()
        {

        }

        private static void connect(string IP_AD, byte[] data)
        {
            //Thread t = new Thread(() => serverContact(IP_AD, data));
            //t.Start(data);
            System.Threading.ThreadPool.QueueUserWorkItem(serverContact, new object[] {IP_AD, Convert.ToBase64String(data)});
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

        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static void serverContact(object state)
        {
            try
            {
                object[] array = state as object[];
                String IP_AD = Convert.ToString(array[0]);
                byte[] data = Convert.FromBase64String(array[1].ToString());
                byte[] bytes = new byte[1024];

                //init
                IPAddress ipAddress = IPAddress.Parse(IP_AD);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);
                Socket client = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                //Connect through the remote socket (endpoint)
                client.Connect(remoteEP);

                // Send test data to the remote device.
                client.Send(data);

                // Receive the response from the remote device.
                int bytesRec = client.Receive(bytes);
                receive(bytes, bytesRec);

                // Release the socket.
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void receive(byte[] receivedpacket, int packetlength)
        {
            String response = Encoding.ASCII.GetString(receivedpacket);
            Console.WriteLine("Response: " + response);
            if (receivedpacket[0] == 2)
            {
                //Experience Point transmission protocol
                if (receivedpacket[1] == 1 && receivedpacket[2] == logincode[0] && receivedpacket[3] == logincode[1] && receivedpacket[4] == logincode[2])
                {
                    //Verified the server and the server accepted the packet
                    String[] items = response.Split('\0');
                    int finalxp = Convert.ToInt32(items[1]);
                    SetControlPropertyThreadSafe(currentForm.xpcount, "Text", finalxp.ToString());
                    SetControlPropertyThreadSafe(currentForm.exp_label, "Text", "Current XP: " + finalxp.ToString());
                    SetControlPropertyThreadSafe(currentForm.progressBar1, "Value", finalxp);
                    SetControlPropertyThreadSafe(currentForm.progressBar2, "Value", finalxp);
                    Console.WriteLine("XP Received: " + finalxp);
                }
            }
            else if (receivedpacket[0] == 3)
            {
                Console.WriteLine("TRYING");
                //Level transmission protocol
                if (receivedpacket[1] == logincode[0] && receivedpacket[2] == logincode[1] && receivedpacket[3] == logincode[2])
                {
                    currentLevel = Convert.ToInt32(Encoding.ASCII.GetString(receivedpacket, 4, 1));
                    Console.WriteLine("Level received");
                    SetControlPropertyThreadSafe(currentForm.label2, "Text", "L  E  V  E  L:  " + currentLevel.ToString());
                    SetControlPropertyThreadSafe(currentForm.inv_level, "Text", "Level: " + currentLevel.ToString());
                    switch (currentLevel)
                    {
                        case 1: 
                            SetControlPropertyThreadSafe(currentForm.level_plaque, "Image", Curry_Client.Properties.Resources.plaque1);
                            break;
                        case 2: 
                            SetControlPropertyThreadSafe(currentForm.level_plaque, "Image", Curry_Client.Properties.Resources.plaque2);
                            break;
                        case 3: 
                            SetControlPropertyThreadSafe(currentForm.level_plaque, "Image", Curry_Client.Properties.Resources.plaque3);
                            break;
                    }
                }
            }
            else if (receivedpacket[0] == 4)
            {
                //MinXP transmission protocol
                if (receivedpacket[1] == logincode[0] && receivedpacket[2] == logincode[1] && receivedpacket[3] == logincode[2])
                {
                    String res = Encoding.ASCII.GetString(receivedpacket);
                    String[] items = res.Split('\0');
                    int minXp = Convert.ToInt32(items[1]);
                    Console.WriteLine("MinXP received");
                    SetControlPropertyThreadSafe(currentForm.progressBar1, "Minimum", minXp);
                    SetControlPropertyThreadSafe(currentForm.progressBar2, "Minimum", minXp);
                }
            }
            else if (receivedpacket[0] == 5)
            {
                //Important: Request XP before getting the Maximum XP!
                //MaxXP transmission protocol
                if (receivedpacket[1] == logincode[0] && receivedpacket[2] == logincode[1] && receivedpacket[3] == logincode[2])
                {
                    String res = Encoding.ASCII.GetString(receivedpacket);
                    String[] items = res.Split('\0');
                    int maxXP = Convert.ToInt32(items[1]);
                    int nextlvl = maxXP - currentXP;
                    Console.WriteLine("MaxXP received");
                    SetControlPropertyThreadSafe(currentForm.progressBar1, "Maximum", maxXP);
                    SetControlPropertyThreadSafe(currentForm.progressBar2, "Maximum", maxXP);
                    SetControlPropertyThreadSafe(currentForm.exp_nextlvl, "Text", "Next level in: " + nextlvl.ToString());
                }
            }
            else if (receivedpacket[0] == 7)
            {
                //User Erase (logout) protocol
                if (receivedpacket[1] == 1)
                {
                    //Verified the server and the server accepted the packet
                    Console.WriteLine("Verification Code Erased from Server");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(label1.Text == "login") 
            {
                loginform lg = new loginform(this);
                lg.ShowDialog();
                label1.Text = "logout";
            }
            else if (label1.Text == "logout")
            {
                eraseUserData();
                label1.Text = "login";
            }
        }


        public byte[] login
        {
            get
            {
                return logincode; 
            }
            set 
            {
                logincode = value; 
            }
        }

        public String serverIP
        {
            get { return ServerIP; }
            set { serverIP = value; }
        }

        public bool getSuperUser
        {
            get 
            { 
                return super; 
            }
            set 
            {
                super = value;
                if (super)
                {
                    enableSuperUser();
                }
                else
                {
                    disableSuperUser();
                }
            }
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
                lg.serverIP = this.serverIP;
                lg.login = this.login;
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
        public void enableSuperUser()
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

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }
    }
}
