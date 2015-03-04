using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.InteropServices;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Curry_Server
{
    public partial class Form1 : Form
    {
        public String getIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
        public Form1()
        {
            InitializeComponent();
        }
        public void WriteToUserConsole(String s)
        {
            consoleBox.Text = consoleBox.Text + "\n" + s;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AllocConsole();
            Console.WriteLine("Server Launch");
            WriteToUserConsole("Teach-Play Server launched at " + getIP());
            makeDirectories();
            //User.createUser("Arpad", "Kovesd", "password", true);
            consoleBox.BackColor = System.Drawing.SystemColors.Window;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button1_Click(object sender, EventArgs e)
        {
            AsynchronousSocketListener listen = new AsynchronousSocketListener();
            WriteToUserConsole("Server Launched!");
        }

        public static void makeDirectories()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!Directory.Exists(appData + "//TeachPlay"))
            {
                Directory.CreateDirectory(appData + "//TeachPlay");
            }
            if (!Directory.Exists(appData + "//TeachPlay//Server"))
            {
                Directory.CreateDirectory(appData + "//TeachPlay//Server");
            }
            if (!File.Exists(User.userXML))
            {
                //makeFile(User.userXML);
                XmlDocument doc = new XmlDocument();
                //doc.Load(User.userXML);
                XmlDeclaration xmldecl;
                xmldecl = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = doc.DocumentElement;
                doc.InsertBefore(xmldecl, root);
                XmlElement lchild = doc.CreateElement("library");
                doc.AppendChild(lchild);
                doc.Save(User.userXML);
            }
        }
        public static void makeFile(String path)
        {
            File.Create(path).Dispose();
        }

        private void promote_button_Click(object sender, EventArgs e)
        {
            //User.setFirstName(1, "Arpad");
            int promoteduserid = User.getID(first_promote.Text, last_promote.Text);
            Console.WriteLine(promoteduserid);
            if (!User.getSuperUser(promoteduserid))
            {
                User.setSuperUser(promoteduserid, true);
                Console.WriteLine(promoteduserid + " User (id) made a superuser");
            }
            else
            {
                MessageBox.Show("Already a superuser");
                Console.WriteLine("Already a superuser");
            }
        }

        private void demote_button_Click(object sender, EventArgs e)
        {
            int demoteduserid = User.getID(first_promote.Text, last_promote.Text);
            if (User.getSuperUser(demoteduserid))
            {
                User.setSuperUser(demoteduserid, false);
            }
            else
            {
                MessageBox.Show("Not a superuser to begin with");
                Console.WriteLine("Not a superuser to begin with");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Password", "Password", "password", -1, -1);
            User.createUser(first_promote.Text, last_promote.Text, "password", false);
        }

    }

    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 2048;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener
    {
        // Thread signal.
        private static Dictionary<Byte[], Int32> userList = new Dictionary<Byte[], Int32>(new ByteArrayComparer());
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public AsynchronousSocketListener()
        {
            StartListening();
        }

        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 32320);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            try
            {
                String content = String.Empty;

                // Retrieve the state object and the handler socket
                // from the asynchronous state object.
                StateObject state = (StateObject)ar.AsyncState;
                Socket handler = state.workSocket;

                // Read data from the client socket. 
                int bytesRead = handler.EndReceive(ar);
                
                Console.WriteLine("Processing Packet of " + bytesRead + " bytes");
                if (bytesRead > 0)
                {
                    // There  might be more data, so store the data received so far.
                    state.sb.Append(Encoding.ASCII.GetString(
                        state.buffer, 0, bytesRead));

                    // Check for end-of-file tag. If it is not there, read 
                    // more data.
                    content = state.sb.ToString();
                    Console.WriteLine(content);
                    if (content.IndexOf("<EOF>") > -1)
                    {
                        Console.WriteLine("<EOF> Found with a buffer of " + state.buffer[0]);
                        //Process data here:
                        byte[] loginpacket = new byte[6];
                        if (state.buffer[0] == 1)
                        {
                            //Packet type: Login verification protocol
                            Console.WriteLine("Loading login data...");
                            //String packet = Encoding.ASCII.GetString(state.buffer, 1,  state.buffer.Length-1);
                            String[] items = content.Split('\0');
                            String firstname = items[0];
                            firstname = firstname.Substring(1);
                            String lastname = items[1]; //NEEDS TRY CATCH
                            String password = items[2];

                            // String lastname = Encoding.ASCII.GetString(state.buffer, 22,  Int32.Parse(Encoding.ASCII.GetString(state.buffer, 21, 1)););
                            //String password = Encoding.ASCII.GetString(state.buffer, 42,  Int32.Parse(Encoding.ASCII.GetString(state.buffer, 41, 1)););
                            Console.WriteLine("Received login protocol: " + firstname + ", " + lastname + ", " + password);
                            //Check if the credentials correspond to actual 

                            int id = findUser(firstname, lastname, password);
                            Console.WriteLine(id);
                            loginpacket[0] = 1;
                            if (id == 0 || id == -1)
                            {
                                loginpacket[1] = 0;
                            }
                            else
                            {
                                Random random = new Random();
                                loginpacket[1] = 1;
                                loginpacket[2] = Convert.ToByte(random.Next(0, 256));
                                loginpacket[3] = Convert.ToByte(random.Next(0, 256));
                                loginpacket[4] = Convert.ToByte(random.Next(0, 256));

                                byte[] userpacket = new byte[3];
                                userpacket[0] = loginpacket[2];
                                userpacket[1] = loginpacket[3];
                                userpacket[2] = loginpacket[4];

                                if (User.getSuperUser(id))
                                {
                                    loginpacket[5] = 1;
                                }
                                else
                                {
                                    loginpacket[5] = 0;
                                }
                                //USER FOUND WITH ID 'id'
                                Console.WriteLine("ID IS" + id);
                                userList.Add(userpacket, id);
                                
                            }
                            SendBytes(handler, loginpacket);

                        }
                        else if (state.buffer[0] == 2)
                        {
                            //Received XP protocol
                            byte[] userpacket = new byte[3];
                            byte[] xppacket = new byte[15];
                            xppacket[0] = 2;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                xppacket[1] = 1; //Indicates success
                                xppacket[2] = userpacket[0];
                                xppacket[3] = userpacket[1];
                                xppacket[4] = userpacket[2];
                                int xp = User.getXP(id);
                                //retrieve xp from xml!
                                byte[] fnl = Encoding.ASCII.GetBytes("\0");
                                fnl.CopyTo(xppacket, 5);
                                byte[] temp = Encoding.ASCII.GetBytes(xp.ToString());
                                temp.CopyTo(xppacket, 6);
                                fnl.CopyTo(xppacket, 6 + Encoding.ASCII.GetByteCount(xp.ToString()));
                            }
                            else
                            {
                                Console.WriteLine("Failure");
                                xppacket[1] = 0; //Indicates failure
                                xppacket[2] = 0;
                                xppacket[3] = 0;
                                xppacket[4] = 0;
                            }
                            SendBytes(handler, xppacket);
                        }
                        else if (state.buffer[0] == 6)
                        {
                            //Received String Array protocol
                            byte[] userpacket = new byte[3];
                            byte[] finalpacket = new byte[60];
                            finalpacket[0] = 6;
                            String[] b = content.Split('\0');
                            String fn = b[0].Substring(1);
                            int fnn = Convert.ToInt32(fn);
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                Console.WriteLine("Confirmed string array protocol");
                                finalpacket[1] = 1; //Indicates success
                                finalpacket[2] = userpacket[0];
                                finalpacket[3] = userpacket[1];
                                finalpacket[4] = userpacket[2];
                                byte[] fnl = Encoding.ASCII.GetBytes("\0");
                                fnl.CopyTo(finalpacket, 5);

                                //Add payload (String array) here:
                                String[] payload = new String[2];
                                payload[0] = User.getFirstName(fnn);
                                payload[1] = User.getLastName(fnn);
                                int arcount = 6;
                                foreach (String s in payload)
                                {
                                    if (s != null && s != String.Empty)
                                    {
                                        byte[] tempa = Encoding.ASCII.GetBytes(s);
                                        tempa.CopyTo(finalpacket, arcount);
                                        fnl.CopyTo(finalpacket, tempa.Length + arcount + 1);
                                        arcount += tempa.Length + 2;
                                    }
                                }
                                byte[] tempb = Encoding.ASCII.GetBytes("<EOF>");
                                tempb.CopyTo(finalpacket, arcount);
                            }
                            else
                            {
                                Console.WriteLine("Failure");
                                finalpacket[1] = 0; //Indicates failure
                                finalpacket[2] = 0;
                                finalpacket[3] = 0;
                                finalpacket[4] = 0;
                            }
                            SendBytes(handler, finalpacket);
                        }
                        else if (state.buffer[0] == 7)
                        {
                            //Remove user from logged in user's list
                            byte[] userpacket = new byte[3];
                            byte[] userdeletepacket = new byte[2];
                            userdeletepacket[0] = 7;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                userdeletepacket[1] = 1;
                                userList.Remove(userpacket);
                            }
                            else
                            {
                                userdeletepacket[1] = 0;
                            }
                            SendBytes(handler, userdeletepacket);
                        }
                        else if (state.buffer[0] == 3)
                        {
                            //Level transmission processing
                            byte[] userpacket = new byte[3];
                            byte[] payload = new byte[5];
                            payload[0] = 3;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            payload[1] = userpacket[0];
                            payload[2] = userpacket[1];
                            payload[3] = userpacket[2];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                int lvl = Settings.getLevel(User.getXP(id));
                                if (lvl > 0 && lvl < 256)
                                {
                                    payload[4] = 1;
                                }
                            }
                            else
                            {
                                payload[4] = 0;
                            }
                            SendBytes(handler, payload);
                        }
                        else if (state.buffer[0] == 4)
                        {
                            //MinXP transmission processing
                            byte[] userpacket = new byte[3];
                            byte[] payload = new byte[9];
                            payload[0] = 4;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            payload[1] = userpacket[0];
                            payload[2] = userpacket[1];
                            payload[3] = userpacket[2];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                int lvl = Settings.getLevel(User.getXP(id));
                                byte[] fnl = Encoding.ASCII.GetBytes("\0");
                                byte[] xp = Encoding.ASCII.GetBytes(Settings.getXp(lvl).ToString());
                                fnl.CopyTo(payload, 4);
                                xp.CopyTo(payload, 5);
                                fnl.CopyTo(payload, xp.Length + 5);
                                if (xp.Length > 3) Console.WriteLine("FATAL: Byte overflow error in packet type 4 processing! XP length too long!");
                            }
                            else
                            {
                                payload[4] = 0;
                            }
                            SendBytes(handler, payload);
                        }
                        else if (state.buffer[0] == 5)
                        {
                            //MaxXP transmission processing
                            byte[] userpacket = new byte[3];
                            byte[] payload = new byte[9];
                            payload[0] = 5;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            payload[1] = userpacket[0];
                            payload[2] = userpacket[1];
                            payload[3] = userpacket[2];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                int lvl = Settings.getLevel(User.getXP(id))+1;
                                byte[] fnl = Encoding.ASCII.GetBytes("\0");
                                byte[] xp = Encoding.ASCII.GetBytes(Settings.getXp(lvl).ToString());
                                fnl.CopyTo(payload, 4);
                                xp.CopyTo(payload, 5);
                                fnl.CopyTo(payload, xp.Length + 5);
                                if (xp.Length > 3) Console.WriteLine("FATAL: Byte overflow error in packet type 5 processing! XP length too long!");
                            }
                            else
                            {
                                payload[4] = 0;
                            }
                            SendBytes(handler, payload);
                        }
                        else if (state.buffer[0] == 8)
                        {
                            //Modify password
                            byte[] userpacket = new byte[3];
                            byte[] payload = new byte[5];
                            payload[0] = 8;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            payload[1] = userpacket[0];
                            payload[2] = userpacket[1];
                            payload[3] = userpacket[2];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                Console.WriteLine("HERE");
                                String[] items = content.Split('\0');
                                //items[1] is the new password and items[2] is the old password
                                Console.WriteLine(items[1]);
                                Console.WriteLine(User.getPassword(id));
                                Console.WriteLine(items[2]);
                                if (items[2].Equals(User.getPassword(id)))
                                {
                                    Console.WriteLine("REACHED");
                                    User.setPassword(id, items[1]);
                                    payload[4] = 1;
                                    //Indicates succcess
                                }
                                else
                                {
                                    //Indicates wrong old password entered
                                    payload[4] = 2;
                                }
                            }
                            else
                            {
                                //Means that could not verify user based on logincode authorization
                                payload[4] = 0;
                            }
                            Console.WriteLine("HI");
                            SendBytes(handler, payload);
                        }
                        else if (state.buffer[0] == 13)
                        {
                            //Return positive that mission was successfully created
                            byte[] userpacket = new byte[3];
                            byte[] payload = new byte[5];
                            payload[0] = 13;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            payload[1] = userpacket[0];
                            payload[2] = userpacket[1];
                            payload[3] = userpacket[2];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                payload[4] = 1;
                                byte[] missionpacket = new byte[state.buffer.Length - 9];
                                try
                                {
                                    Array.Copy(state.buffer, 4, missionpacket, 0, state.buffer.Length - 9);
                                    Object obj = ByteArrayToObject(missionpacket);
                                    Mission mis = (Mission)obj;
                                    Missions.createMission(mis);
                                }
                                catch (Exception f)
                                {
                                    Console.WriteLine(f.ToString());
                                }
                            }
                            else
                            {
                                payload[4] = 0;
                            }
                            SendBytes(handler, payload);
                        }
                        else if (state.buffer[0] == 23)
                        {
                            //Gold transmision processing
                            byte[] userpacket = new byte[3];
                            byte[] payload = new byte[9];
                            payload[0] = 23;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            payload[1] = userpacket[0];
                            payload[2] = userpacket[1];
                            payload[3] = userpacket[2];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                int gold = User.getGold(id);
                                byte[] fnl = Encoding.ASCII.GetBytes("\0");
                                byte[] goldpacket = Encoding.ASCII.GetBytes(gold.ToString());
                                fnl.CopyTo(payload, 4);
                                goldpacket.CopyTo(payload, 5);
                                fnl.CopyTo(payload, goldpacket.Length + 5);
                                if (goldpacket.Length > 3) Console.WriteLine("FATAL: Byte overflow error in packet type 5 processing! Gold length too long!");
                            }
                            else
                            {
                                payload[4] = 0;
                            }
                            SendBytes(handler, payload);
                        }
                        else if (state.buffer[0] == 24)
                        {
                            //Mana transmission processing
                            byte[] userpacket = new byte[3];
                            byte[] payload = new byte[9];
                            payload[0] = 24;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            payload[1] = userpacket[0];
                            payload[2] = userpacket[1];
                            payload[3] = userpacket[2];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                int mana = User.getMana(id);
                                byte[] fnl = Encoding.ASCII.GetBytes("\0");
                                byte[] manapacket = Encoding.ASCII.GetBytes(mana.ToString());
                                fnl.CopyTo(payload, 4);
                                manapacket.CopyTo(payload, 5);
                                fnl.CopyTo(payload, manapacket.Length + 5);
                                if (manapacket.Length > 3) Console.WriteLine("FATAL: Byte overflow error in packet type 5 processing! Mana length too long!");
                            }
                            else
                            {
                                payload[4] = 0;
                            }
                            SendBytes(handler, payload);
                        }
                        else if (state.buffer[0] == 29)
                        {
                            //Request for list of users
                            byte[] userpacket = new byte[3];
                            byte[] finalpacket = new byte[1024 + 5];
                            finalpacket[0] = 29;
                            userpacket[0] = state.buffer[1];
                            userpacket[1] = state.buffer[2];
                            userpacket[2] = state.buffer[3];
                            int id = 0;
                            if (userList.TryGetValue(userpacket, out id))
                            {
                                finalpacket[1] = userpacket[0];
                                finalpacket[2] = userpacket[1];
                                finalpacket[3] = userpacket[2];
                                byte[] fnl = Encoding.ASCII.GetBytes("\0");
                                fnl.CopyTo(finalpacket, 4);

                                byte[] users = User.getUserList();
                                users.CopyTo(finalpacket, 5);
                            }
                            else
                            {
                                Console.WriteLine("Failure");
                                finalpacket[1] = 0; //Indicates failure
                                finalpacket[2] = 0;
                                finalpacket[3] = 0;
                                finalpacket[4] = 0;
                            }
                            SendBytes(handler, finalpacket);
                        }


                        // All the data has been read from the 
                        // client. Display it on the console.
                        Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                            content.Length, content);
                        // Echo the data back to the client.
                    }
                    else
                    {
                        // Not all data received. Get more.
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReadCallback), state);
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendBytes(Socket handler, byte[] byteData)
        {
            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        private static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }

        public static int findUser(String firstname, String lastname, String password)
        {
            
            try
            {

                String xmlfile = User.userXML;
                System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(xmlfile);
                int tempid = 0;
                bool flag = false;
                bool flag1 = false;
                bool flag2 = false;
                int i = 0;
                int tempint = -10;
                string tempstring = "";
                while (reader.Read())
                {

                    i++;
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        if (tempint + 1 == i)
                        {
                            if (tempstring == "firstname")
                            {
                                if (firstname.CompareTo(reader.Value) == 0)
                                {
                                    flag = true;
                                } else{
                                    flag = false;
                                }
                                //Console.WriteLine(i);
                                Console.WriteLine("'" + firstname + "'");
                                Console.WriteLine(reader.Value);
                                Console.WriteLine(flag);
                                Console.WriteLine(firstname.Length + "    " + reader.Value.Length);
                            }
                            else if (tempstring == "lastname")
                            {
                                if (lastname.CompareTo(reader.Value) == 0)
                                {
                                    flag1 = true;
                                }
                                else
                                {
                                    flag1 = false;
                                }
                                Console.WriteLine(lastname);
                                Console.WriteLine(reader.Value);
                                Console.WriteLine(flag1);
                            }
                            else if (tempstring == "password")
                            {
                                if (password.CompareTo(reader.Value) == 0)
                                {
                                    flag2 = true;
                                }
                                else
                                {
                                    flag2 = false;
                                }
                                Console.WriteLine(password);
                                Console.WriteLine(reader.Value);
                                Console.WriteLine(flag2);
                            }
                            tempstring = "";
                            tempint = -10;
                        }
                    }
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "user")
                        {
                            if (flag && flag1 && flag2)
                            {
                                return tempid;
                            }
                            tempid = Int32.Parse(reader.GetAttribute(0));
                            flag = false;
                            flag1 = false;
                            flag2 = false;

                        }
                        if (reader.Name == "firstname")
                        {
                            tempint = i;
                            tempstring = "firstname";
                        }
                        if (reader.Name == "lastname")
                        {
                            tempint = i;
                            tempstring = "lastname";
                        }
                        if (reader.Name == "password")
                        {
                            tempint = i;
                            tempstring = "password";
                        }
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return -1;
        }

        public Dictionary<byte[], Int32> loggedUsers
        {
            get { return userList;}
            set { userList = value;}
        }
    }
}
