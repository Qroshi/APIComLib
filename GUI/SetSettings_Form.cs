using APIComLib.Models.Settings;
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
    public partial class SetSettings_Form : Form
    {
        public Settings settings { get; set; } = new Settings();
        public SetSettings_Form()
        {
            InitializeComponent();
        }

        private void Set_Click(object sender, EventArgs e)
        {
            try
            {
                settings.deviceName = Name.Text;

                if (Tunnel.Checked == true)
                    settings.tunnel = new Tunnel(1);
                else
                    settings.tunnel = new Tunnel(0);

                if (StatusLed.Checked == true)
                    settings.statusLed = new StatusLed(1);
                else
                    settings.statusLed = new StatusLed(0);

                settings.rgbw = new Rgbw(Int32.Parse(ColorMode.Text),
                                        Int32.Parse(OutputMode.Text),
                                        Int32.Parse(PwmFreq.Text),
                                        Int32.Parse(ButtonMode.Text));
                this.Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter valid data", "Error");
            }
        }
    }
}
