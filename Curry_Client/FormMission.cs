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
    public partial class FormMission : Form
    {
        EnumMission missiontype = EnumMission.MultipleChoice;
        public FormMission()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateForm();
        }

        private void FormMission_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Multiple Choice";
            updateForm();
        }
        public void updateForm()
        {
            if (comboBox1.Text == "Multiple Choice")
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                listBox1.Items.Clear();
                listBox1.Visible = false;
                listBox1.Visible = true;
                missiontype = EnumMission.MultipleChoice;
                label2.Visible = false;
                textBox1.Visible = false;
                this.Size = new Size(449, 465);
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label3.Visible = true;
                textBox2.Visible = true;
                buttonFinish.Location = new Point(179, 392);
                buttonAdd.Visible = true;
                buttonAdd.Location = new Point(179, 213);
                buttonRemove.Visible = true;
                buttonRemove.Location = new Point(179, 242);
                listBox1.Location = new Point(12, 289);
                numericUpDown2.Location = new Point(12, 367);
                label4.Location = new Point(49, 369);
                numericUpDown3.Location = new Point(136, 367);
                label5.Location = new Point(200, 369);
                checkBox1.Location = new Point(258, 367);
                numericUpDown4.Location = new Point(361, 364);
            }
            else if (comboBox1.Text == "Free Response")
            {
                questionList.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                listBox1.Items.Clear();
                listBox1.Visible = false;
                listBox1.Visible = true;
                missiontype = EnumMission.FreeResponse;
                label2.Visible = false;
                textBox1.Visible = false;
                this.Size = new Size(449, 387);
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label3.Visible = true;
                textBox2.Visible = true;
                buttonFinish.Location = new Point(179, 317);
                buttonAdd.Visible = true;
                buttonAdd.Location = new Point(179, 98);
                buttonRemove.Visible = true;
                buttonRemove.Location = new Point(179, 128);
                listBox1.Location = new Point(12, 157);
                numericUpDown2.Location = new Point(12, 241);
                label4.Location = new Point(49, 243);
                numericUpDown3.Location = new Point(136, 241);
                label5.Location = new Point(200, 243);
                checkBox1.Location = new Point(258, 242);
                numericUpDown4.Location = new Point(361, 241);
            }
            else if (comboBox1.Text == "File Upload") //441, 212
            {
                questionList.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                listBox1.Items.Clear();
                listBox1.Visible = false;
                listBox1.Visible = false;
                missiontype = EnumMission.FileUpload;
                label2.Visible = true;
                textBox1.Visible = true;
                this.Size = new Size(441, 300);
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label3.Visible = false;
                textBox2.Visible = false;
                buttonFinish.Location = new Point(179, 218);
                buttonAdd.Visible = false;
                buttonRemove.Visible = false;
                numericUpDown2.Location = new Point(12, 176);
                label4.Location = new Point(49, 178);
                numericUpDown3.Location = new Point(136, 176);
                label5.Location = new Point(200, 178);
                checkBox1.Location = new Point(258, 177);
                numericUpDown4.Location = new Point(361, 176);
            }
            else if (comboBox1.Text == "Text")
            {
                questionList.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                listBox1.Items.Clear();
                listBox1.Visible = false;
                missiontype = EnumMission.FileUpload;
                label2.Visible = true;
                textBox1.Visible = true;
                this.Size = new Size(441, 300);
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label3.Visible = false;
                textBox2.Visible = false;
                buttonFinish.Location = new Point(179, 218);
                buttonAdd.Visible = false;
                buttonRemove.Visible = false;
                numericUpDown2.Location = new Point(12, 176);
                label4.Location = new Point(49, 178);
                numericUpDown3.Location = new Point(136, 176);
                label5.Location = new Point(200, 178);
                checkBox1.Location = new Point(258, 177);
                numericUpDown4.Location = new Point(361, 176);
            } 
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                numericUpDown4.Enabled = true;
            }
            else
            {
                numericUpDown4.Enabled = false;
            }
        }
        List<Question> questionList = new List<Question>();
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (missiontype == EnumMission.MultipleChoice)
            {
                if (!(listBox1.Items.Count == 0))
                {
                    String t = listBox1.SelectedItem.ToString();
                    listBox1.Items.Remove(listBox1.SelectedItem);
                    foreach (Question q in questionList)
                    {
                        if (q.getPrompt() == listBox1.SelectedItem.ToString())
                        {
                            questionList.Remove(q);
                            break;
                        }
                    }
                }
            }
            else
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            numericUpDown2.Maximum = listBox1.Items.Count;
            if (numericUpDown2.Maximum == 0)
            {
                numericUpDown2.Maximum = 1;
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (missiontype == EnumMission.MultipleChoice)
            {
                if (!listBox1.Items.Contains(textBox2.Text))
                {
                    listBox1.Items.Add(textBox2.Text);
                    int i;
                    if (radioButton1.Checked == true)
                    {
                        i = 1;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        i = 2;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        i = 3;
                    }
                    else if (radioButton4.Checked == true)
                    {
                        i = 4;
                    }
                    else
                    {
                        i = 0;
                    }
                    if (!(i == 0))
                    {
                        Question q = new Question(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, i);
                        questionList.Add(q);
                    }
                    else
                    {
                        //NONE SELECTED
                    }
                }
            }
            else
            {
                if (!listBox1.Items.Contains(textBox2.Text))
                {
                    listBox1.Items.Add(textBox2.Text);
                }
            }
            numericUpDown2.Maximum = listBox1.Items.Count;
            if (numericUpDown2.Maximum == 0)
            {
                numericUpDown2.Maximum = 1;
            }
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {

        }
    }
}
