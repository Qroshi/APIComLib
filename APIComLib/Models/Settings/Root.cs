using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models.Settings
{
    public class Root
    {
        public Settings settings { get; set; }
        public Root(Settings settings) { this.settings = settings; }
    }
}
