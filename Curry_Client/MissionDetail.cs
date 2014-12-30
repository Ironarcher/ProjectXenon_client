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
    internal partial class MissionDetail : Form
    {
        public FormSuperUser mainForm;
        public Mission passthrough;

        public MissionDetail(Form callingForm, Mission pt)
        {
            mainForm = callingForm as FormSuperUser;
            passthrough = pt;
            InitializeComponent();
        }

        private void MissionDetail_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && numericUpDown3.Value != 0 && numericUpDown1.Value < numericUpDown2.Value)
            {
                passthrough.title = textBox1.Text;
                passthrough.missionStart = dateTimePicker1.Value;
                passthrough.missionEnd = dateTimePicker2.Value;
                passthrough.lvlStartEligible = Convert.ToInt32(numericUpDown1.Value);
                passthrough.lvlEndEligible = Convert.ToInt32(numericUpDown2.Value);
                passthrough.xpreward = Convert.ToInt32(numericUpDown3.Value);
                passthrough.goldreward = Convert.ToInt32(numericUpDown4.Value);

                //Send Mission to server to store
            }
            else
            {
                MessageBox.Show("Some fields are invalid.");
            }
        }
    }
}
