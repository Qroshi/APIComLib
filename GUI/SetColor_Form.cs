using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class SetColor_Form : Form
    {
        public string colorValue { get; set; }
        public int colorFade { get; set; }
        public SetColor_Form()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, EventArgs e)
        {
            colorValue = Color.Text;
            try
            {
                colorFade = Int32.Parse(Fade.Text);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid number", "Error");
            }
        }
    }
}
