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
    public partial class SetIP_Form : Form
    {
        public string IPAddress { get; set; }
        public SetIP_Form()
        {
            InitializeComponent();
        }
        private bool IsTextAValidIPAddress(string text)
        {
            System.Net.IPAddress test;
            return System.Net.IPAddress.TryParse(text, out test);
        }
        private void Set_Click(object sender, EventArgs e)
        {
            if (IsTextAValidIPAddress(IP.Text))
            {
                IPAddress = IP.Text;
                this.Close();
            }
            else
                MessageBox.Show("Enter valid IP","Error");
        }
    }
}
