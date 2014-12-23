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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.missionPanel = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.mission_start = new System.Windows.Forms.Button();
            this.mission_description = new System.Windows.Forms.Label();
            this.mission_format = new System.Windows.Forms.Label();
            this.mission_xp = new System.Windows.Forms.Label();
            this.mission_name = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.newMissionList2 = new System.Windows.Forms.ListBox();
            this.collab_page = new System.Windows.Forms.TabPage();
            this.inv_page = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.item_use = new System.Windows.Forms.Button();
            this.item_description = new System.Windows.Forms.Label();
            this.item_type = new System.Windows.Forms.Label();
            this.item_name = new System.Windows.Forms.Label();
            this.inv_level = new System.Windows.Forms.Label();
            this.exp_label = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.level_plaque = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.badge_page = new System.Windows.Forms.TabPage();
            this.leaderboard_page = new System.Windows.Forms.TabPage();
            this.setting_page = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.userbox = new System.Windows.Forms.GroupBox();
            this.manacount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.xpcount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gold = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newMissionList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.oldMissionList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_xp = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.mission_page.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.missionPanel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.inv_page.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.level_plaque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.userbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
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
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // mission_page
            // 
            this.mission_page.Controls.Add(this.groupBox5);
            this.mission_page.Controls.Add(this.groupBox4);
            this.mission_page.Controls.Add(this.groupBox3);
            this.mission_page.Location = new System.Drawing.Point(4, 22);
            this.mission_page.Name = "mission_page";
            this.mission_page.Padding = new System.Windows.Forms.Padding(3);
            this.mission_page.Size = new System.Drawing.Size(528, 544);
            this.mission_page.TabIndex = 0;
            this.mission_page.Text = "Missions";
            this.mission_page.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.missionPanel);
            this.groupBox5.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(6, 218);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(516, 320);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // missionPanel
            // 
            this.missionPanel.BackColor = System.Drawing.Color.Transparent;
            this.missionPanel.Controls.Add(this.button_xp);
            this.missionPanel.Location = new System.Drawing.Point(6, 19);
            this.missionPanel.Name = "missionPanel";
            this.missionPanel.Size = new System.Drawing.Size(504, 295);
            this.missionPanel.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.mission_start);
            this.groupBox4.Controls.Add(this.mission_description);
            this.groupBox4.Controls.Add(this.mission_format);
            this.groupBox4.Controls.Add(this.mission_xp);
            this.groupBox4.Controls.Add(this.mission_name);
            this.groupBox4.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox4.Location = new System.Drawing.Point(344, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(178, 203);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mission Description";
            // 
            // mission_start
            // 
            this.mission_start.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.mission_start.ForeColor = System.Drawing.Color.Black;
            this.mission_start.Location = new System.Drawing.Point(43, 173);
            this.mission_start.Name = "mission_start";
            this.mission_start.Size = new System.Drawing.Size(98, 23);
            this.mission_start.TabIndex = 4;
            this.mission_start.Text = "Start Mission";
            this.mission_start.UseVisualStyleBackColor = true;
            // 
            // mission_description
            // 
            this.mission_description.AutoSize = true;
            this.mission_description.ForeColor = System.Drawing.Color.Black;
            this.mission_description.Location = new System.Drawing.Point(6, 79);
            this.mission_description.MaximumSize = new System.Drawing.Size(168, 95);
            this.mission_description.Name = "mission_description";
            this.mission_description.Size = new System.Drawing.Size(69, 14);
            this.mission_description.TabIndex = 3;
            this.mission_description.Text = "Description:";
            // 
            // mission_format
            // 
            this.mission_format.AutoSize = true;
            this.mission_format.ForeColor = System.Drawing.Color.Black;
            this.mission_format.Location = new System.Drawing.Point(6, 59);
            this.mission_format.Name = "mission_format";
            this.mission_format.Size = new System.Drawing.Size(46, 14);
            this.mission_format.TabIndex = 2;
            this.mission_format.Text = "Format:";
            // 
            // mission_xp
            // 
            this.mission_xp.AutoSize = true;
            this.mission_xp.ForeColor = System.Drawing.Color.Black;
            this.mission_xp.Location = new System.Drawing.Point(6, 39);
            this.mission_xp.Name = "mission_xp";
            this.mission_xp.Size = new System.Drawing.Size(54, 14);
            this.mission_xp.TabIndex = 1;
            this.mission_xp.Text = "XP Given:";
            // 
            // mission_name
            // 
            this.mission_name.AutoSize = true;
            this.mission_name.ForeColor = System.Drawing.Color.Black;
            this.mission_name.Location = new System.Drawing.Point(6, 19);
            this.mission_name.Name = "mission_name";
            this.mission_name.Size = new System.Drawing.Size(39, 14);
            this.mission_name.TabIndex = 0;
            this.mission_name.Text = "Name:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.newMissionList2);
            this.groupBox3.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupBox3.Location = new System.Drawing.Point(6, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 203);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Available Missions";
            // 
            // newMissionList2
            // 
            this.newMissionList2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newMissionList2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newMissionList2.Enabled = false;
            this.newMissionList2.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMissionList2.FormattingEnabled = true;
            this.newMissionList2.ItemHeight = 14;
            this.newMissionList2.Location = new System.Drawing.Point(6, 21);
            this.newMissionList2.Name = "newMissionList2";
            this.newMissionList2.Size = new System.Drawing.Size(319, 168);
            this.newMissionList2.TabIndex = 1;
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
            this.inv_page.Controls.Add(this.groupBox6);
            this.inv_page.Controls.Add(this.inv_level);
            this.inv_page.Controls.Add(this.exp_label);
            this.inv_page.Controls.Add(this.label3);
            this.inv_page.Controls.Add(this.progressBar2);
            this.inv_page.Controls.Add(this.tableLayoutPanel1);
            this.inv_page.Controls.Add(this.level_plaque);
            this.inv_page.Controls.Add(this.pictureBox2);
            this.inv_page.Location = new System.Drawing.Point(4, 22);
            this.inv_page.Name = "inv_page";
            this.inv_page.Size = new System.Drawing.Size(528, 544);
            this.inv_page.TabIndex = 2;
            this.inv_page.Text = "Inventory";
            this.inv_page.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.item_use);
            this.groupBox6.Controls.Add(this.item_description);
            this.groupBox6.Controls.Add(this.item_type);
            this.groupBox6.Controls.Add(this.item_name);
            this.groupBox6.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(359, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(163, 124);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Item Description";
            // 
            // item_use
            // 
            this.item_use.Location = new System.Drawing.Point(39, 96);
            this.item_use.Name = "item_use";
            this.item_use.Size = new System.Drawing.Size(75, 23);
            this.item_use.TabIndex = 3;
            this.item_use.Text = "Equip/Use";
            this.item_use.UseVisualStyleBackColor = true;
            // 
            // item_description
            // 
            this.item_description.AutoSize = true;
            this.item_description.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_description.Location = new System.Drawing.Point(6, 53);
            this.item_description.MaximumSize = new System.Drawing.Size(160, 50);
            this.item_description.Name = "item_description";
            this.item_description.Size = new System.Drawing.Size(69, 14);
            this.item_description.TabIndex = 2;
            this.item_description.Text = "Description:";
            // 
            // item_type
            // 
            this.item_type.AutoSize = true;
            this.item_type.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_type.Location = new System.Drawing.Point(6, 35);
            this.item_type.Name = "item_type";
            this.item_type.Size = new System.Drawing.Size(33, 14);
            this.item_type.TabIndex = 1;
            this.item_type.Text = "Type:";
            // 
            // item_name
            // 
            this.item_name.AutoSize = true;
            this.item_name.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.Location = new System.Drawing.Point(6, 17);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(39, 14);
            this.item_name.TabIndex = 0;
            this.item_name.Text = "Name:";
            // 
            // inv_level
            // 
            this.inv_level.AutoSize = true;
            this.inv_level.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inv_level.Location = new System.Drawing.Point(133, 12);
            this.inv_level.Name = "inv_level";
            this.inv_level.Size = new System.Drawing.Size(61, 19);
            this.inv_level.TabIndex = 8;
            this.inv_level.Text = "Level: 1";
            // 
            // exp_label
            // 
            this.exp_label.AutoSize = true;
            this.exp_label.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exp_label.Location = new System.Drawing.Point(133, 72);
            this.exp_label.Name = "exp_label";
            this.exp_label.Size = new System.Drawing.Size(87, 19);
            this.exp_label.TabIndex = 6;
            this.exp_label.Text = "Current XP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(133, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Next level in:";
            // 
            // progressBar2
            // 
            this.progressBar2.BackColor = System.Drawing.Color.White;
            this.progressBar2.Location = new System.Drawing.Point(127, 98);
            this.progressBar2.MarqueeAnimationSpeed = 1000;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(143, 23);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar2.TabIndex = 4;
            this.progressBar2.Value = 30;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 134);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(517, 404);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // level_plaque
            // 
            this.level_plaque.Image = global::Curry_Client.Properties.Resources.plaque1;
            this.level_plaque.Location = new System.Drawing.Point(280, 19);
            this.level_plaque.Name = "level_plaque";
            this.level_plaque.Size = new System.Drawing.Size(70, 90);
            this.level_plaque.TabIndex = 7;
            this.level_plaque.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Curry_Client.Properties.Resources.unknownpicture;
            this.pictureBox2.Location = new System.Drawing.Point(11, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 100);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
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
            this.label1.Location = new System.Drawing.Point(700, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "login";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // userbox
            // 
            this.userbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userbox.BackColor = System.Drawing.Color.Transparent;
            this.userbox.Controls.Add(this.manacount);
            this.userbox.Controls.Add(this.label6);
            this.userbox.Controls.Add(this.xpcount);
            this.userbox.Controls.Add(this.label5);
            this.userbox.Controls.Add(this.pictureBox4);
            this.userbox.Controls.Add(this.label2);
            this.userbox.Controls.Add(this.gold);
            this.userbox.Controls.Add(this.pictureBox1);
            this.userbox.Controls.Add(this.progressBar1);
            this.userbox.Location = new System.Drawing.Point(559, 59);
            this.userbox.Name = "userbox";
            this.userbox.Size = new System.Drawing.Size(200, 175);
            this.userbox.TabIndex = 8;
            this.userbox.TabStop = false;
            this.userbox.Text = "Student";
            // 
            // manacount
            // 
            this.manacount.AutoSize = true;
            this.manacount.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manacount.Location = new System.Drawing.Point(148, 90);
            this.manacount.Name = "manacount";
            this.manacount.Size = new System.Drawing.Size(36, 19);
            this.manacount.TabIndex = 16;
            this.manacount.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(111, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 27);
            this.label6.TabIndex = 15;
            this.label6.Text = "M";
            // 
            // xpcount
            // 
            this.xpcount.AutoSize = true;
            this.xpcount.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpcount.Location = new System.Drawing.Point(148, 62);
            this.xpcount.Name = "xpcount";
            this.xpcount.Size = new System.Drawing.Size(27, 19);
            this.xpcount.TabIndex = 14;
            this.xpcount.Text = "30";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mistral", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(114, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 26);
            this.label5.TabIndex = 13;
            this.label5.Text = "XP";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Curry_Client.Properties.Resources.goldcoinsmall;
            this.pictureBox4.Location = new System.Drawing.Point(116, 26);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(26, 26);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "L  E  V  E  L:  1";
            // 
            // gold
            // 
            this.gold.AutoSize = true;
            this.gold.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gold.Location = new System.Drawing.Point(148, 30);
            this.gold.Name = "gold";
            this.gold.Size = new System.Drawing.Size(18, 19);
            this.gold.TabIndex = 2;
            this.gold.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Curry_Client.Properties.Resources.unknownpicture;
            this.pictureBox1.Location = new System.Drawing.Point(8, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(6, 125);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(188, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.newMissionList);
            this.groupBox1.Location = new System.Drawing.Point(560, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 199);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New Missions";
            // 
            // newMissionList
            // 
            this.newMissionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newMissionList.BackColor = System.Drawing.Color.SteelBlue;
            this.newMissionList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newMissionList.Enabled = false;
            this.newMissionList.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMissionList.FormattingEnabled = true;
            this.newMissionList.ItemHeight = 14;
            this.newMissionList.Location = new System.Drawing.Point(7, 19);
            this.newMissionList.Name = "newMissionList";
            this.newMissionList.Size = new System.Drawing.Size(188, 154);
            this.newMissionList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.oldMissionList);
            this.groupBox2.Location = new System.Drawing.Point(560, 445);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 167);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Finished Missions";
            // 
            // oldMissionList
            // 
            this.oldMissionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oldMissionList.BackColor = System.Drawing.Color.SteelBlue;
            this.oldMissionList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.oldMissionList.Enabled = false;
            this.oldMissionList.Font = new System.Drawing.Font("Gadugi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldMissionList.FormattingEnabled = true;
            this.oldMissionList.ItemHeight = 14;
            this.oldMissionList.Location = new System.Drawing.Point(6, 19);
            this.oldMissionList.Name = "oldMissionList";
            this.oldMissionList.Size = new System.Drawing.Size(188, 140);
            this.oldMissionList.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(595, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "contact";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Enable Super User";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(431, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Disable Super User";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_xp
            // 
            this.button_xp.Location = new System.Drawing.Point(64, 50);
            this.button_xp.Name = "button_xp";
            this.button_xp.Size = new System.Drawing.Size(75, 23);
            this.button_xp.TabIndex = 0;
            this.button_xp.Text = "getxp";
            this.button_xp.UseVisualStyleBackColor = true;
            this.button_xp.Click += new System.EventHandler(this.button_xp_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(767, 624);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
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
            this.mission_page.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.missionPanel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.inv_page.ResumeLayout(false);
            this.inv_page.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.level_plaque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.userbox.ResumeLayout(false);
            this.userbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
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
        private System.Windows.Forms.ListBox newMissionList;
        private System.Windows.Forms.ListBox oldMissionList;
        private System.Windows.Forms.Label gold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel missionPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox newMissionList2;
        private System.Windows.Forms.Label exp_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label inv_level;
        private System.Windows.Forms.PictureBox level_plaque;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button mission_start;
        private System.Windows.Forms.Label mission_description;
        private System.Windows.Forms.Label mission_format;
        private System.Windows.Forms.Label mission_xp;
        private System.Windows.Forms.Label mission_name;
        private System.Windows.Forms.Label manacount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label xpcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label item_description;
        private System.Windows.Forms.Label item_type;
        private System.Windows.Forms.Label item_name;
        private System.Windows.Forms.Button item_use;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_xp;



    }
}

