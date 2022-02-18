using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models.State
{
    public class Root
    {
        public Rgbw rgbw { get; set; }

        public Root(Rgbw rgbw) { this.rgbw = rgbw; }
    }
}
