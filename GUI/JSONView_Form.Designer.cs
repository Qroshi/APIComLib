namespace GUI
{
    partial class JSONView_Form
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
            this.JSONText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // JSONText
            // 
            this.JSONText.Location = new System.Drawing.Point(36, 42);
            this.JSONText.Multiline = true;
            this.JSONText.Name = "JSONText";
            this.JSONText.ReadOnly = true;
            this.JSONText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.JSONText.Size = new System.Drawing.Size(370, 420);
            this.JSONText.TabIndex = 0;
            // 
            // JSONView_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 504);
            this.Controls.Add(this.JSONText);
            this.Name = "JSONView_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JSONView_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox JSONText;
    }
}