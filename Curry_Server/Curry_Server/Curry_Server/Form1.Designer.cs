﻿namespace Curry_Server
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
            this.button1 = new System.Windows.Forms.Button();
            this.consoleBox = new System.Windows.Forms.TextBox();
            this.first_promote = new System.Windows.Forms.TextBox();
            this.last_promote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.promote_button = new System.Windows.Forms.Button();
            this.demote_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Launch Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(13, 13);
            this.consoleBox.Multiline = true;
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.Size = new System.Drawing.Size(412, 290);
            this.consoleBox.TabIndex = 2;
            // 
            // first_promote
            // 
            this.first_promote.Location = new System.Drawing.Point(95, 349);
            this.first_promote.Name = "first_promote";
            this.first_promote.Size = new System.Drawing.Size(106, 20);
            this.first_promote.TabIndex = 3;
            // 
            // last_promote
            // 
            this.last_promote.Location = new System.Drawing.Point(212, 349);
            this.last_promote.Name = "last_promote";
            this.last_promote.Size = new System.Drawing.Size(127, 20);
            this.last_promote.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Superuser control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Last Name";
            // 
            // promote_button
            // 
            this.promote_button.Location = new System.Drawing.Point(178, 375);
            this.promote_button.Name = "promote_button";
            this.promote_button.Size = new System.Drawing.Size(75, 23);
            this.promote_button.TabIndex = 12;
            this.promote_button.Text = "Promote";
            this.promote_button.UseVisualStyleBackColor = true;
            this.promote_button.Click += new System.EventHandler(this.promote_button_Click);
            // 
            // demote_button
            // 
            this.demote_button.Location = new System.Drawing.Point(264, 375);
            this.demote_button.Name = "demote_button";
            this.demote_button.Size = new System.Drawing.Size(75, 23);
            this.demote_button.TabIndex = 13;
            this.demote_button.Text = "Demote";
            this.demote_button.UseVisualStyleBackColor = true;
            this.demote_button.Click += new System.EventHandler(this.demote_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(95, 375);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Create New";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 447);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.demote_button);
            this.Controls.Add(this.promote_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.last_promote);
            this.Controls.Add(this.first_promote);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox consoleBox;
        private System.Windows.Forms.TextBox first_promote;
        private System.Windows.Forms.TextBox last_promote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button promote_button;
        private System.Windows.Forms.Button demote_button;
        private System.Windows.Forms.Button button2;

    }
}

