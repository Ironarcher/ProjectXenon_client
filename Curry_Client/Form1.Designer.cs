namespace Curry_Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.mission_page = new System.Windows.Forms.TabPage();
            this.collab_page = new System.Windows.Forms.TabPage();
            this.inv_page = new System.Windows.Forms.TabPage();
            this.badge_page = new System.Windows.Forms.TabPage();
            this.leaderboard_page = new System.Windows.Forms.TabPage();
            this.setting_page = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.userbox = new System.Windows.Forms.GroupBox();
            this.gold = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.userbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Gadugi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(12, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(197, 25);
            this.title.TabIndex = 0;
            this.title.Text = "Gamified Classroom";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.mission_page);
            this.tabControl1.Controls.Add(this.collab_page);
            this.tabControl1.Controls.Add(this.inv_page);
            this.tabControl1.Controls.Add(this.badge_page);
            this.tabControl1.Controls.Add(this.leaderboard_page);
            this.tabControl1.Controls.Add(this.setting_page);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(17, 42);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(536, 570);
            this.tabControl1.TabIndex = 6;
            // 
            // mission_page
            // 
            this.mission_page.Location = new System.Drawing.Point(4, 22);
            this.mission_page.Name = "mission_page";
            this.mission_page.Padding = new System.Windows.Forms.Padding(3);
            this.mission_page.Size = new System.Drawing.Size(528, 544);
            this.mission_page.TabIndex = 0;
            this.mission_page.Text = "Missions";
            this.mission_page.UseVisualStyleBackColor = true;
            // 
            // collab_page
            // 
            this.collab_page.Location = new System.Drawing.Point(4, 22);
            this.collab_page.Name = "collab_page";
            this.collab_page.Padding = new System.Windows.Forms.Padding(3);
            this.collab_page.Size = new System.Drawing.Size(528, 544);
            this.collab_page.TabIndex = 1;
            this.collab_page.Text = "Collaboration";
            this.collab_page.UseVisualStyleBackColor = true;
            // 
            // inv_page
            // 
            this.inv_page.Location = new System.Drawing.Point(4, 22);
            this.inv_page.Name = "inv_page";
            this.inv_page.Size = new System.Drawing.Size(528, 544);
            this.inv_page.TabIndex = 2;
            this.inv_page.Text = "Inventory";
            this.inv_page.UseVisualStyleBackColor = true;
            // 
            // badge_page
            // 
            this.badge_page.Location = new System.Drawing.Point(4, 22);
            this.badge_page.Name = "badge_page";
            this.badge_page.Size = new System.Drawing.Size(528, 544);
            this.badge_page.TabIndex = 3;
            this.badge_page.Text = "Badges";
            this.badge_page.UseVisualStyleBackColor = true;
            // 
            // leaderboard_page
            // 
            this.leaderboard_page.Location = new System.Drawing.Point(4, 22);
            this.leaderboard_page.Name = "leaderboard_page";
            this.leaderboard_page.Size = new System.Drawing.Size(528, 544);
            this.leaderboard_page.TabIndex = 4;
            this.leaderboard_page.Text = "Leaderboard";
            this.leaderboard_page.UseVisualStyleBackColor = true;
            // 
            // setting_page
            // 
            this.setting_page.Location = new System.Drawing.Point(4, 22);
            this.setting_page.Name = "setting_page";
            this.setting_page.Size = new System.Drawing.Size(528, 544);
            this.setting_page.TabIndex = 5;
            this.setting_page.Text = "Settings";
            this.setting_page.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(702, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // userbox
            // 
            this.userbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userbox.Controls.Add(this.label2);
            this.userbox.Controls.Add(this.gold);
            this.userbox.Controls.Add(this.pictureBox1);
            this.userbox.Controls.Add(this.progressBar1);
            this.userbox.Location = new System.Drawing.Point(559, 59);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(200, 194);
            this.userbox.TabIndex = 8;
            this.userbox.TabStop = false;
            this.userbox.Text = "Student";
            // 
            // gold
            // 
            this.gold.AutoSize = true;
            this.gold.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gold.Location = new System.Drawing.Point(130, 36);
            this.gold.Name = "gold";
            this.gold.Size = new System.Drawing.Size(38, 14);
            this.gold.TabIndex = 2;
            this.gold.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 94);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(8, 120);
            this.progressBar1.MarqueeAnimationSpeed = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(188, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(560, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 179);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Missions";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Enabled = false;
            this.listBox1.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(7, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 140);
            this.listBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Location = new System.Drawing.Point(560, 445);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 167);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finished Missions";
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.Enabled = false;
            this.listBox2.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 14;
            this.listBox2.Location = new System.Drawing.Point(6, 19);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(188, 140);
            this.listBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Level: 0";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(767, 624);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(783, 662);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.userbox.ResumeLayout(false);
            this.userbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage mission_page;
        private System.Windows.Forms.TabPage collab_page;
        private System.Windows.Forms.TabPage inv_page;
        private System.Windows.Forms.TabPage badge_page;
        private System.Windows.Forms.TabPage leaderboard_page;
        private System.Windows.Forms.TabPage setting_page;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox userbox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label gold;
        private System.Windows.Forms.Label label2;



    }
}

