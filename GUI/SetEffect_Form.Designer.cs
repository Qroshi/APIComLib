namespace GUI
{
    partial class SetEffect_Form
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EffectID = new System.Windows.Forms.Label();
            this.EffectFade = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.EffectStep = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Set
            // 
            this.Set.Location = new System.Drawing.Point(177, 211);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(75, 23);
            this.Set.TabIndex = 0;
            this.Set.Text = "Set";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // EffectID
            // 
            this.EffectID.AutoSize = true;
            this.EffectID.Location = new System.Drawing.Point(188, 29);
            this.EffectID.Name = "EffectID";
            this.EffectID.Size = new System.Drawing.Size(51, 15);
            this.EffectID.TabIndex = 2;
            this.EffectID.Text = "Effect ID";
            // 
            // EffectFade
            // 
            this.EffectFade.AutoSize = true;
            this.EffectFade.Location = new System.Drawing.Point(188, 79);
            this.EffectFade.Name = "EffectFade";
            this.EffectFade.Size = new System.Drawing.Size(63, 15);
            this.EffectFade.TabIndex = 4;
            this.EffectFade.Text = "Effect fade";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(168, 97);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 3;
            // 
            // EffectStep
            // 
            this.EffectStep.AutoSize = true;
            this.EffectStep.Location = new System.Drawing.Point(189, 134);
            this.EffectStep.Name = "EffectStep";
            this.EffectStep.Size = new System.Drawing.Size(63, 15);
            this.EffectStep.TabIndex = 6;
            this.EffectStep.Text = "Effect Step";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(168, 152);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 5;
            // 
            // SetEffect_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 297);
            this.Controls.Add(this.EffectStep);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.EffectFade);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.EffectID);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Set);
            this.Name = "SetEffect_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetEffect_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Set;
        private TextBox textBox1;
        private Label EffectID;
        private Label EffectFade;
        private TextBox textBox2;
        private Label EffectStep;
        private TextBox textBox3;
    }
}