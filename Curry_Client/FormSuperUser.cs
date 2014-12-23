using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curry_Client
{
    public partial class FormSuperUser : Form
    {
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
