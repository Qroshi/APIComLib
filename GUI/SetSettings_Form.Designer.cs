namespace GUI
{
    partial class SetSettings_Form
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
            this.Set = new System.Windows.Forms.Button();
            this.Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ColorMode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OutputMode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PwmFreq = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ButtonMode = new System.Windows.Forms.TextBox();
            this.Tunnel = new System.Windows.Forms.CheckBox();
            this.StatusLed = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Set
            // 
            this.Set.Location = new System.Drawing.Point(138, 362);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(75, 23);
            this.Set.TabIndex = 0;
            this.Set.Text = "Set";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(35, 59);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(100, 23);
            this.Name.TabIndex = 1;
            this.Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tunnel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "StatusLed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "ColorMode";
            // 
            // ColorMode
            // 
            this.ColorMode.Location = new System.Drawing.Point(35, 214);
            this.ColorMode.Name = "ColorMode";
            this.ColorMode.Size = new System.Drawing.Size(100, 23);
            this.ColorMode.TabIndex = 7;
            this.ColorMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "OutputMode";
            // 
            // OutputMode
            // 
            this.OutputMode.Location = new System.Drawing.Point(35, 262);
            this.OutputMode.Name = "OutputMode";
            this.OutputMode.Size = new System.Drawing.Size(100, 23);
            this.OutputMode.TabIndex = 9;
            this.OutputMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "PwmFreq";
            // 
            // PwmFreq
            // 
            this.PwmFreq.Location = new System.Drawing.Point(214, 214);
            this.PwmFreq.Name = "PwmFreq";
            this.PwmFreq.Size = new System.Drawing.Size(100, 23);
            this.PwmFreq.TabIndex = 11;
            this.PwmFreq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(214, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "ButtonMode";
            // 
            // ButtonMode
            // 
            this.ButtonMode.Location = new System.Drawing.Point(214, 262);
            this.ButtonMode.Name = "ButtonMode";
            this.ButtonMode.Size = new System.Drawing.Size(100, 23);
            this.ButtonMode.TabIndex = 13;
            this.ButtonMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tunnel
            // 
            this.Tunnel.AutoSize = true;
            this.Tunnel.Location = new System.Drawing.Point(35, 122);
            this.Tunnel.Name = "Tunnel";
            this.Tunnel.Size = new System.Drawing.Size(68, 19);
            this.Tunnel.TabIndex = 15;
            this.Tunnel.Text = "Enabled";
            this.Tunnel.UseVisualStyleBackColor = true;
            // 
            // StatusLed
            // 
            this.StatusLed.AutoSize = true;
            this.StatusLed.Location = new System.Drawing.Point(214, 122);
            this.StatusLed.Name = "StatusLed";
            this.StatusLed.Size = new System.Drawing.Size(68, 19);
            this.StatusLed.TabIndex = 16;
            this.StatusLed.Text = "Enabled";
            this.StatusLed.UseVisualStyleBackColor = true;
            // 
            // SetSettings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 421);
            this.Controls.Add(this.StatusLed);
            this.Controls.Add(this.Tunnel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ButtonMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PwmFreq);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OutputMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ColorMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.Set);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set settings (leave empty to ignore field)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Set;
        private TextBox Name;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox ColorMode;
        private Label label5;
        private TextBox OutputMode;
        private Label label6;
        private TextBox PwmFreq;
        private Label label7;
        private TextBox ButtonMode;
        private CheckBox Tunnel;
        private CheckBox StatusLed;
    }
}