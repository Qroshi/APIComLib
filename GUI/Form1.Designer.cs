namespace GUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SetIP = new System.Windows.Forms.Button();
            this.GetStatus = new System.Windows.Forms.Button();
            this.SetColor = new System.Windows.Forms.Button();
            this.SetEffect = new System.Windows.Forms.Button();
            this.SetFavColors = new System.Windows.Forms.Button();
            this.GetSettings = new System.Windows.Forms.Button();
            this.SetSettings = new System.Windows.Forms.Button();
            this.GetJSON = new System.Windows.Forms.Button();
            this.CurrentColor = new System.Windows.Forms.TextBox();
            this.CurrentEffect = new System.Windows.Forms.TextBox();
            this.ExtParam = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SetIP
            // 
            this.SetIP.Location = new System.Drawing.Point(26, 36);
            this.SetIP.Name = "SetIP";
            this.SetIP.Size = new System.Drawing.Size(111, 23);
            this.SetIP.TabIndex = 0;
            this.SetIP.Text = "Set IP";
            this.SetIP.UseVisualStyleBackColor = true;
            this.SetIP.Click += new System.EventHandler(this.SetIP_Click);
            // 
            // GetStatus
            // 
            this.GetStatus.Enabled = false;
            this.GetStatus.Location = new System.Drawing.Point(26, 94);
            this.GetStatus.Name = "GetStatus";
            this.GetStatus.Size = new System.Drawing.Size(111, 23);
            this.GetStatus.TabIndex = 1;
            this.GetStatus.Text = "Get state";
            this.GetStatus.UseVisualStyleBackColor = true;
            this.GetStatus.Click += new System.EventHandler(this.GetStatus_ClickAsync);
            // 
            // SetColor
            // 
            this.SetColor.Enabled = false;
            this.SetColor.Location = new System.Drawing.Point(26, 123);
            this.SetColor.Name = "SetColor";
            this.SetColor.Size = new System.Drawing.Size(111, 23);
            this.SetColor.TabIndex = 2;
            this.SetColor.Text = "Set color";
            this.SetColor.UseVisualStyleBackColor = true;
            this.SetColor.Click += new System.EventHandler(this.SetColor_ClickAsync);
            // 
            // SetEffect
            // 
            this.SetEffect.Enabled = false;
            this.SetEffect.Location = new System.Drawing.Point(26, 152);
            this.SetEffect.Name = "SetEffect";
            this.SetEffect.Size = new System.Drawing.Size(111, 23);
            this.SetEffect.TabIndex = 3;
            this.SetEffect.Text = "Set effect";
            this.SetEffect.UseVisualStyleBackColor = true;
            this.SetEffect.Click += new System.EventHandler(this.SetEffect_ClickAsync);
            // 
            // SetFavColors
            // 
            this.SetFavColors.Enabled = false;
            this.SetFavColors.Location = new System.Drawing.Point(26, 181);
            this.SetFavColors.Name = "SetFavColors";
            this.SetFavColors.Size = new System.Drawing.Size(111, 23);
            this.SetFavColors.TabIndex = 4;
            this.SetFavColors.Text = "Set favorite colors";
            this.SetFavColors.UseVisualStyleBackColor = true;
            this.SetFavColors.Click += new System.EventHandler(this.SetFavColors_ClickAsync);
            // 
            // GetSettings
            // 
            this.GetSettings.Enabled = false;
            this.GetSettings.Location = new System.Drawing.Point(26, 278);
            this.GetSettings.Name = "GetSettings";
            this.GetSettings.Size = new System.Drawing.Size(111, 23);
            this.GetSettings.TabIndex = 5;
            this.GetSettings.Text = "Get settings";
            this.GetSettings.UseVisualStyleBackColor = true;
            this.GetSettings.Click += new System.EventHandler(this.GetSettings_ClickAsync);
            // 
            // SetSettings
            // 
            this.SetSettings.Enabled = false;
            this.SetSettings.Location = new System.Drawing.Point(26, 307);
            this.SetSettings.Name = "SetSettings";
            this.SetSettings.Size = new System.Drawing.Size(111, 23);
            this.SetSettings.TabIndex = 6;
            this.SetSettings.Text = "Set settings";
            this.SetSettings.UseVisualStyleBackColor = true;
            this.SetSettings.Click += new System.EventHandler(this.SetSettings_ClickAsync);
            // 
            // GetJSON
            // 
            this.GetJSON.Enabled = false;
            this.GetJSON.Location = new System.Drawing.Point(359, 210);
            this.GetJSON.Name = "GetJSON";
            this.GetJSON.Size = new System.Drawing.Size(141, 23);
            this.GetJSON.TabIndex = 7;
            this.GetJSON.Text = "Get last operation JSON";
            this.GetJSON.UseVisualStyleBackColor = true;
            this.GetJSON.Click += new System.EventHandler(this.GetJSON_Click);
            // 
            // CurrentColor
            // 
            this.CurrentColor.Location = new System.Drawing.Point(359, 103);
            this.CurrentColor.Name = "CurrentColor";
            this.CurrentColor.ReadOnly = true;
            this.CurrentColor.Size = new System.Drawing.Size(141, 23);
            this.CurrentColor.TabIndex = 8;
            this.CurrentColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CurrentEffect
            // 
            this.CurrentEffect.Location = new System.Drawing.Point(359, 157);
            this.CurrentEffect.Name = "CurrentEffect";
            this.CurrentEffect.ReadOnly = true;
            this.CurrentEffect.Size = new System.Drawing.Size(141, 23);
            this.CurrentEffect.TabIndex = 9;
            this.CurrentEffect.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExtParam
            // 
            this.ExtParam.AutoSize = true;
            this.ExtParam.Location = new System.Drawing.Point(164, 98);
            this.ExtParam.Name = "ExtParam";
            this.ExtParam.Size = new System.Drawing.Size(159, 19);
            this.ExtParam.TabIndex = 10;
            this.ExtParam.Text = "Use extended parameters";
            this.ExtParam.UseVisualStyleBackColor = true;
            this.ExtParam.CheckedChanged += new System.EventHandler(this.ExtParam_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Color";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Effect";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 384);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExtParam);
            this.Controls.Add(this.CurrentEffect);
            this.Controls.Add(this.CurrentColor);
            this.Controls.Add(this.GetJSON);
            this.Controls.Add(this.SetSettings);
            this.Controls.Add(this.GetSettings);
            this.Controls.Add(this.SetFavColors);
            this.Controls.Add(this.SetEffect);
            this.Controls.Add(this.SetColor);
            this.Controls.Add(this.GetStatus);
            this.Controls.Add(this.SetIP);
            this.Name = "Form1";
            this.Text = "GUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button SetIP;
        private Button GetStatus;
        private Button SetColor;
        private Button SetEffect;
        private Button SetFavColors;
        private Button GetSettings;
        private Button SetSettings;
        private Button GetJSON;
        private TextBox CurrentColor;
        private TextBox CurrentEffect;
        private CheckBox ExtParam;
        private Label label1;
        private Label label2;
    }
}