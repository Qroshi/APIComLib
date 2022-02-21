namespace GUI
{
    partial class SetFavColors_Form
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
            this.Add = new System.Windows.Forms.Button();
            this.ColorList = new System.Windows.Forms.ListBox();
            this.Color = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Set
            // 
            this.Set.Location = new System.Drawing.Point(162, 269);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(75, 23);
            this.Set.TabIndex = 0;
            this.Set.Text = "Set";
            this.Set.UseVisualStyleBackColor = true;
            this.Set.Click += new System.EventHandler(this.Set_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(70, 152);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 1;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // ColorList
            // 
            this.ColorList.FormattingEnabled = true;
            this.ColorList.ItemHeight = 15;
            this.ColorList.Location = new System.Drawing.Point(228, 32);
            this.ColorList.Name = "ColorList";
            this.ColorList.Size = new System.Drawing.Size(160, 199);
            this.ColorList.TabIndex = 2;
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(35, 111);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(144, 23);
            this.Color.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Color value in HEX";
            // 
            // SetFavColors_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 356);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.ColorList);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Set);
            this.Name = "SetFavColors_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetFavColors_Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Set;
        private Button Add;
        private ListBox ColorList;
        private TextBox Color;
        private Label label1;
    }
}