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
    class Missions
    {
        public static String userXML = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//TeachPlay//Server//missiondata.xml";

        public static void createMission(Mission m)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList elemList = doc.GetElementsByTagName("mission");
            int newid = elemList.Count + 1;
            XmlElement e = doc.CreateElement("mission");
            XmlAttribute a = doc.CreateAttribute("id");
            a.Value = newid.ToString();
            e.Attributes.Append(a);
            XmlElement titlechild = doc.CreateElement("title");
            titlechild.AppendChild(doc.CreateTextNode(m.title));
            XmlElement typechild = doc.CreateElement("type");
            typechild.AppendChild(doc.CreateTextNode(m.type.ToString()));
            XmlElement lvlstartchild = doc.CreateElement("lvlStartEligible");
            lvlstartchild.AppendChild(doc.CreateTextNode(m.lvlStartEligible.ToString()));
            XmlElement lvlendchild = doc.CreateElement("lvlEndEligible");
            lvlendchild.AppendChild(doc.CreateTextNode(m.lvlEndEligible.ToString()));
            XmlElement missionstartchild = doc.CreateElement("missionStart");
            missionstartchild.AppendChild(doc.CreateTextNode(m.missionStart.ToString()));
            XmlElement missionendchild = doc.CreateElement("missionEnd");
            missionendchild.AppendChild(doc.CreateTextNode(m.missionEnd.ToString()));
            XmlElement xprewardchild = doc.CreateElement("xpreward");
            xprewardchild.AppendChild(doc.CreateTextNode(m.xpreward.ToString()));
            XmlElement goldrewardchild = doc.CreateElement("goldreward");
            goldrewardchild.AppendChild(doc.CreateTextNode(m.goldreward.ToString()));
            e.AppendChild(titlechild);
            e.AppendChild(typechild);
            e.AppendChild(lvlstartchild);
            e.AppendChild(lvlendchild);
            e.AppendChild(missionstartchild);
            e.AppendChild(missionendchild);
            e.AppendChild(xprewardchild);
            e.AppendChild(goldrewardchild);

            int currentquestionnumber = 1;
            foreach (Question q in m.questions)
            {
                XmlElement nodee = doc.CreateElement("question");
                XmlAttribute nodea = doc.CreateAttribute("number");
                nodea.Value = currentquestionnumber.ToString();
                nodee.Attributes.Append(nodea);

                XmlElement promptchild = doc.CreateElement("prompt");
                promptchild.AppendChild(doc.CreateTextNode(m.questions[currentquestionnumber-1].getPrompt()));
                XmlElement answerachild = doc.CreateElement("AnswerA");
                answerachild.AppendChild(doc.CreateTextNode(m.questions[currentquestionnumber - 1].getAnswers()[0]));
                XmlElement answerbchild = doc.CreateElement("Answer B");
                answerbchild.AppendChild(doc.CreateTextNode(m.questions[currentquestionnumber - 1].getAnswers()[1]));
                XmlElement answercchild = doc.CreateElement("AnswerC");
                answercchild.AppendChild(doc.CreateTextNode(m.questions[currentquestionnumber - 1].getAnswers()[2]));
                XmlElement answerdchild = doc.CreateElement("AnswerD");
                answerdchild.AppendChild(doc.CreateTextNode(m.questions[currentquestionnumber - 1].getAnswers()[3]));
                XmlElement correctanswerchild = doc.CreateElement("correctanswer");
                correctanswerchild.AppendChild(doc.CreateTextNode(m.questions[currentquestionnumber - 1].getCorrectAnswer().ToString()));
                nodee.AppendChild(promptchild);
                nodee.AppendChild(answerachild);
                nodee.AppendChild(answerbchild);
                nodee.AppendChild(answercchild);
                nodee.AppendChild(answerdchild);
                nodee.AppendChild(correctanswerchild);

                e.AppendChild(nodee);
                currentquestionnumber++;
            }
            doc.ChildNodes.Item(1).AppendChild(e);
            doc.Save(userXML);

            
        }
        public static String getLevelCap()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(userXML);
            XmlNodeList xnList = doc.SelectNodes("/generalsettings");
            XmlNode xn = xnList[0];
            return xn["levelcap"].InnerText;
        }
    }
}
