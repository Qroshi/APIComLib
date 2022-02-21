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
    public partial class JSONView_Form : Form
    {
        public JSONView_Form(string JSON)
        {
            InitializeComponent();
            JSONText.Text = JSON;
        }
    }
}
