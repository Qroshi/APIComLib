using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models.Settings
{
    public class StatusLed
    {
        public int enabled { get; set; }
        public StatusLed(int enabled) { this.enabled = enabled; }
    }
}
