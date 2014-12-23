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
            //User.createUser("Joseph", "Stafford", "password", true);
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

        private void consoleBox_TextChanged(object sender, EventArgs e)
        {

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
    }

    // State object for reading client data asynchronously
    public class StateObject
    {
        // Client  socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousSocketListener
    {
        // Thread signal.
        private static Dictionary<Int32, Byte[]> userList = new Dictionary<Int32, Byte[]>();
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
                        byte[] loginpacket = new byte[5];
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
                                //USER FOUND WITH ID 'id'
                                userList.Add(id, userpacket);
                                
                            }

                        }


                        // All the data has been read from the 
                        // client. Display it on the console.
                        Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                            content.Length, content);
                        // Echo the data back to the client.
                        SendBytes(handler, loginpacket);
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
                                flag = firstname.Equals(reader.Value);
                                //Console.WriteLine(i);
                                Console.WriteLine("'" + firstname + "'");
                                Console.WriteLine(reader.Value);
                                Console.WriteLine(flag);
                                Console.WriteLine(firstname.Length + "    " + reader.Value.Length);
                            }
                            else if (tempstring == "lastname")
                            {
                                flag1 = firstname.Equals(reader.Value);
                                Console.WriteLine(lastname);
                                Console.WriteLine(reader.Value);
                                Console.WriteLine(flag1);
                            }
                            else if (tempstring == "password")
                            {
                                flag2 = firstname.Equals(reader.Value);
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

        public Dictionary<Int32, byte[]> loggedUsers
        {
            get { return userList;}
            set { userList = value;}
        }
    }
    public class User {
        /*
         * getFirstName(id) returns the first name of user with id "id"
         * getLastName, getPassword, getSuperUser are the same
         * getInfo(id) returns a string array where [0] is firstname, [1] is lastname, [2] is password
         * setFirstName(id, name) sets the first name of user with id "id" to "name"
         * setLastName, setPassword, setSuperUser are the same
         * Example: User.setLastName(1, "Kovesdy"); sets user id 1's last name to Kovesdy
         * 
         * createUser(firstname, lastname, password, superuser)
         * creates a user with newest available id with the given info
         */
        public static String userXML = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//TeachPlay//Server//users.xml";
        public static String getFirstName(int id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        return e.ChildNodes.Item(0).FirstChild.Value;
                    }
                }
            }
            return "";
        }
        public static String getLastName(int id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        return e.ChildNodes.Item(1).FirstChild.Value;
                    }
                }
            }
            return "";
        }
        public static String getPassword(int id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        return e.ChildNodes.Item(2).FirstChild.Value;
                    }
                }
            }
            return "";
        }
        public static int createUser(String firstname, String lastname, String password, bool superuser)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            int newid = elemList.Count+1;           
            XmlElement e = doc.CreateElement("user");
            XmlAttribute a = doc.CreateAttribute("id");
            a.Value = newid.ToString();
            e.Attributes.Append(a);
            XmlElement fchild = doc.CreateElement("firstname");
            fchild.AppendChild(doc.CreateTextNode(firstname));
            XmlElement lchild = doc.CreateElement("lastname");
            lchild.AppendChild(doc.CreateTextNode(lastname));
            XmlElement pchild = doc.CreateElement("password");
            pchild.AppendChild(doc.CreateTextNode(password));
            XmlElement schild = doc.CreateElement("superuser");
            schild.AppendChild(doc.CreateTextNode(superuser.ToString()));
            e.AppendChild(fchild);
            e.AppendChild(lchild);
            e.AppendChild(pchild);
            e.AppendChild(schild);
            doc.ChildNodes.Item(1).AppendChild(e);
            doc.Save(userXML);
            //doc.FirstChild.AppendChild
            return newid;
        }
        public static String[] getInfo(int id) //[0] is fisrtname, [1] is lastname, [2] is password
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        return new String[] {e.ChildNodes.Item(0).FirstChild.Value, e.ChildNodes.Item(1).FirstChild.Value, e.ChildNodes.Item(2).FirstChild.Value};
                    }
                }
            }
            return null;
        }
        public bool getSuperUser(int id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        return e.ChildNodes.Item(3).FirstChild.Value == "True";
                    }
                }
            }
            return false;
        }

        public void setFirstName(int id, String value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        e.ChildNodes.Item(0).FirstChild.Value = value;
                    }
                }
            }
        }
        public void setLastName(int id, String value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        e.ChildNodes.Item(1).FirstChild.Value = value;
                    }
                }
            }
        }
        public void setPassword(int id, String value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        e.ChildNodes.Item(2).FirstChild.Value = value;
                    }
                }
            }
        }
        public void setSuperUser(int id, bool value)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    int tid = Int32.Parse(e.GetAttribute("id"));
                    if (id == tid)
                    {
                        e.ChildNodes.Item(3).FirstChild.Value = value.ToString();
                    }
                }
            }
        }
    }

}
