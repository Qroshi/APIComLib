using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models.Settings
{
    public class Settings
    {
        public string deviceName { get; set; }
        public Tunnel tunnel { get; set; }
        public StatusLed statusLed { get; set; }
        public Rgbw rgbw { get; set; }
    }
}
