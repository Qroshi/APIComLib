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
    public partial class SetEffect_Form : Form
    {
        public int effectID { get; set; }
        public int effectFade { get; set; }
        public int effectStep { get; set; }
        public SetEffect_Form()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, EventArgs e)
        {
            try
            {
                effectID = Int32.Parse(EffectID.Text);
                effectFade = Int32.Parse(EffectFade.Text);
                effectStep = Int32.Parse(EffectStep.Text);
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid number", "Error");
            }
        }
    }
}
