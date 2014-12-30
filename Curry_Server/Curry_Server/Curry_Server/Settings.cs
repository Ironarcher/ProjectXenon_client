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
    class Settings
    {
        public static String userXML = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//TeachPlay//Server//serversettings.xml";
        public static String getFirstLevelXp()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList xnList = doc.SelectNodes("/generalsettings");
            XmlNode xn = xnList[0];
            return xn["firstlevelxp"].InnerText;
        }
        public static String getLevelCap()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList xnList = doc.SelectNodes("/generalsettings");
            XmlNode xn = xnList[0];
            return xn["levelcap"].InnerText;
        }
        public static String getMultipler()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(userXML);
                XmlNodeList xnList = doc.SelectNodes("/generalsettings");
                XmlNode xn = xnList[0];
                return xn["multiplier"].InnerText;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return null;
        }
        public static int getLevel(int xp)
        {
            try
            {
                Console.WriteLine(getFirstLevelXp());
                Console.WriteLine(getMultipler());
                double firstlevelxp = Convert.ToDouble(getFirstLevelXp());
                double multipler = Convert.ToDouble(getMultipler());
                double a = ((multipler * firstlevelxp) - firstlevelxp) / 2;
                double b = Convert.ToInt32(getFirstLevelXp()) - a;
                int c = -xp;
                double sqrtpart = b * b - 4 * a * c;
                double x = (-b + System.Math.Sqrt(sqrtpart)) / (2 * a);
                Console.WriteLine(x);
                return Convert.ToInt32(Math.Floor(x));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return 0;
        }
        public static int getXp(int level)
        {
            try
            {
                double multipler = Convert.ToDouble(getMultipler());
                double startlevelxp = Convert.ToDouble(getFirstLevelXp());
                return Convert.ToInt32(Math.Floor(((multipler / 2) * level * level) + ((startlevelxp - (multipler / 2)) * level)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return 0;
        }
    }
}
