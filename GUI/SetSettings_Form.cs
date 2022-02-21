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
                if (Int32.Parse(Tunnel.Text) == 0 || Int32.Parse(Tunnel.Text) == 1)
                    settings.tunnel = new Tunnel(Int32.Parse(Tunnel.Text));
                else
                    throw new ArgumentOutOfRangeException("Tunnel", $"Value of Tunnel must be 0 or 1.");
                if (Int32.Parse(StatusLed.Text) == 0 || Int32.Parse(StatusLed.Text) == 1)
                    settings.statusLed = new StatusLed(Int32.Parse(StatusLed.Text));
                else
                    throw new ArgumentOutOfRangeException("StatusLed", $"Value of StatusLed must be 0 or 1.");
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
