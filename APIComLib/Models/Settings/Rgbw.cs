using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models.Settings
{
    public class Rgbw
    {
        public int colorMode { get; set; }
        public int outputMode { get; set; }
        public int pwmFreq { get; set; }
        public int buttonMode { get; set; }
        public List<OrderedDictionary> fieldsPreferences { get; set; }
        public bool ShouldSerializefieldsPreferences()
        { return false; }
        public Rgbw(int colorMode, int outputMode, int pwmFreq, int buttonMode)
        {
            this.colorMode = colorMode;
            this.outputMode = outputMode;
            this.pwmFreq = pwmFreq;
            this.buttonMode = buttonMode;
        }
    }
}
