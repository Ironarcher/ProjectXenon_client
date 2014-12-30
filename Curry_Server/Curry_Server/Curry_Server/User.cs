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
    class User
    {
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
        public static byte[] getUserList()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            byte[] returnlist = new byte[1024];
            int writerplace = 0;
            byte[] fnl = Encoding.ASCII.GetBytes("\0");
            for (int i = 0; i < elemList.Count; i++)
            {
                XmlNode x = elemList.Item(i);
                if (x.NodeType == XmlNodeType.Element)
                {
                    XmlElement e = (XmlElement)x;
                    byte[] firstnamebytes = Encoding.ASCII.GetBytes(e.ChildNodes.Item(0).FirstChild.Value);
                    byte[] lastnamebytes = Encoding.ASCII.GetBytes(e.ChildNodes.Item(1).FirstChild.Value);
                    firstnamebytes.CopyTo(returnlist, writerplace);
                    fnl.CopyTo(returnlist, writerplace + firstnamebytes.Length);
                    lastnamebytes.CopyTo(returnlist, writerplace + firstnamebytes.Length + 1);
                    fnl.CopyTo(returnlist, writerplace + firstnamebytes.Length + lastnamebytes.Length + 1);
                    writerplace += firstnamebytes.Length + lastnamebytes.Length + 2;
                }
            }
            return returnlist;
        }
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
        public static void addMission(int missionID)
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
                    XmlElement nodee = doc.CreateElement("mission");
                    XmlAttribute nodea = doc.CreateAttribute("id");
                    nodea.Value = missionID.ToString();
                    nodee.Attributes.Append(nodea);

                    XmlElement gradechild = doc.CreateElement("grade");
                    gradechild.AppendChild(doc.CreateTextNode("N/A"));
                    XmlElement attemptschild = doc.CreateElement("attempts");
                    attemptschild.AppendChild(doc.CreateTextNode("0"));
                    nodee.AppendChild(gradechild);
                    nodee.AppendChild(attemptschild);

                    e.AppendChild(nodee);
                }
            }
        }
        public static int getGold(int id)
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
                        return Convert.ToInt32(e.ChildNodes.Item(4).FirstChild.Value);
                    }
                }
            }
            return 0;
        }
        public static int getMana(int id)
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
                        return Convert.ToInt32(e.ChildNodes.Item(5).FirstChild.Value);
                    }
                }
            }
            return 0;
        }
        public static int getXP(int id)
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
                        return Convert.ToInt32(e.ChildNodes.Item(6).FirstChild.Value);
                    }
                }
            }
            return 0;
        }
        public static int createUser(String firstname, String lastname, String password, bool superuser)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("user");
            int newid = elemList.Count + 1;
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
            XmlElement goldchild = doc.CreateElement("gold");
            goldchild.AppendChild(doc.CreateTextNode(Convert.ToString(0)));
            XmlElement manachild = doc.CreateElement("mana");
            manachild.AppendChild(doc.CreateTextNode(Convert.ToString(100)));
            XmlElement xpchild = doc.CreateElement("xp");
            xpchild.AppendChild(doc.CreateTextNode(Convert.ToString(0)));
            XmlElement groupchild = doc.CreateElement("group");
            groupchild.AppendChild(doc.CreateTextNode("None"));
            XmlElement avatarchild = doc.CreateElement("avatar");
            avatarchild.AppendChild(doc.CreateTextNode("None"));
            XmlElement emailchild = doc.CreateElement("email");
            emailchild.AppendChild(doc.CreateTextNode("None"));
            e.AppendChild(fchild);
            e.AppendChild(lchild);
            e.AppendChild(pchild);
            e.AppendChild(schild);
            e.AppendChild(goldchild);
            e.AppendChild(manachild);
            e.AppendChild(xpchild);
            e.AppendChild(groupchild);
            e.AppendChild(avatarchild);
            e.AppendChild(emailchild);
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
                        return new String[] { e.ChildNodes.Item(0).FirstChild.Value, e.ChildNodes.Item(1).FirstChild.Value, e.ChildNodes.Item(2).FirstChild.Value };
                    }
                }
            }
            return null;
        }
        public static bool getSuperUser(int id)
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

        public static void setFirstName(int id, String value)
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
            doc.Save(userXML);
        }
        public static void setLastName(int id, String value)
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
            doc.Save(userXML);
        }
        public static void setPassword(int id, String value)
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
            doc.Save(userXML);
        }
        public static void setSuperUser(int id, bool value)
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
                        if (value == true)
                        {
                            Console.WriteLine("SUperuser working");
                            e.ChildNodes.Item(3).FirstChild.Value = "True";
                        }
                        else
                        {
                            e.ChildNodes.Item(3).FirstChild.Value = "False";
                        }
                    }
                }
            }
            doc.Save(userXML);
        }
        public static void setGold(int id, int value)
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
                        e.ChildNodes.Item(4).FirstChild.Value = value.ToString();
                    }
                }
            }
            doc.Save(userXML);
        }
        public static void setMana(int id, int value)
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
                        e.ChildNodes.Item(5).FirstChild.Value = value.ToString();
                    }
                }
            }
            doc.Save(userXML);
        }
        public static void setXP(int id, int value)
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
                        e.ChildNodes.Item(6).FirstChild.Value = value.ToString();
                    }
                }
            }
            doc.Save(userXML);
        }
        public static int getID(String firstname, String lastname)
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
                    if (e.ChildNodes.Item(0).FirstChild.Value == firstname && e.ChildNodes.Item(1).FirstChild.Value == lastname)
                    {
                        return tid;
                    }
                }
            }
            return 0;
        }
    }

    public class ByteArrayComparer : IEqualityComparer<byte[]>
    {
        public bool Equals(byte[] left, byte[] right)
        {
            if (left == null || right == null)
            {
                return left == right;
            }
            if (left.Length != right.Length)
            {
                return false;
            }
            for (int i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }
            return true;
        }
        public int GetHashCode(byte[] key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            int sum = 0;
            foreach (byte cur in key)
            {
                sum += cur;
            }
            return sum;
        }
    }
}
