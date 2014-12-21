namespace Curry_Client
{
    partial class loginform
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
            this.label1 = new System.Windows.Forms.Label();
            this.firstnamebox = new System.Windows.Forms.TextBox();
            this.lastnamebox = new System.Windows.Forms.TextBox();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Enter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gadugi", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log-In";
            // 
            // firstnamebox
            // 
            this.firstnamebox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.firstnamebox.Location = new System.Drawing.Point(12, 51);
            this.firstnamebox.Name = "firstnamebox";
            this.firstnamebox.Size = new System.Drawing.Size(199, 20);
            this.firstnamebox.TabIndex = 1;
            this.firstnamebox.Text = "First Name";
            this.firstnamebox.Click += new System.EventHandler(this.firstnamebox_Click);
            this.firstnamebox.TextChanged += new System.EventHandler(this.firstnamebox_TextChanged);
            this.firstnamebox.Leave += new System.EventHandler(this.firstnamebox_Leave);
            // 
            // lastnamebox
            // 
            this.lastnamebox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lastnamebox.Location = new System.Drawing.Point(12, 77);
            this.lastnamebox.Name = "lastnamebox";
            this.lastnamebox.Size = new System.Drawing.Size(199, 20);
            this.lastnamebox.TabIndex = 2;
            this.lastnamebox.Text = "Last Name";
            this.lastnamebox.Enter += new System.EventHandler(this.lastnamebox_Enter);
            this.lastnamebox.Leave += new System.EventHandler(this.lastnamebox_Leave);
            // 
            // passwordbox
            // 
            this.passwordbox.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.passwordbox.Location = new System.Drawing.Point(12, 103);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.Size = new System.Drawing.Size(199, 20);
            this.passwordbox.TabIndex = 3;
            this.passwordbox.Text = "Password";
            this.passwordbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.passwordbox.Enter += new System.EventHandler(this.passwordbox_Enter);
            this.passwordbox.Leave += new System.EventHandler(this.passwordbox_Leave);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Curriculum"});
            this.comboBox1.Location = new System.Drawing.Point(12, 129);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.Enter += new System.EventHandler(this.comboBox1_Enter);
            // 
            // Enter
            // 
            this.Enter.Location = new System.Drawing.Point(75, 156);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(75, 23);
            this.Enter.TabIndex = 5;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            this.Enter.Click += new System.EventHandler(this.Enter_Click);
            // 
            // loginform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(232, 192);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.lastnamebox);
            this.Controls.Add(this.firstnamebox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(80000000, 8000000);
            this.MinimizeBox = false;
            this.Name = "loginform";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Teach-Play: Login";
            this.Load += new System.EventHandler(this.loginform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstnamebox;
        private System.Windows.Forms.TextBox lastnamebox;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Enter;
    }
}