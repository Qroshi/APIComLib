using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models.State
{
    public class Rgbw
    {
        public int colorMode { get; set; }
        public int effectID { get; set; }
        public string desiredColor { get; set; }
        public string currentColor { get; set; }
        public string lastOnColor { get; set; }
        public DurationsMs durationsMs { get; set; }
        public OrderedDictionary effectNames { get; set; }
        public OrderedDictionary favColors { get; set; }
        public Rgbw() { }
        public bool ShouldSerializeeffectNames()
        {
            return (effectNames != null);
        }
        public bool ShouldSerializefavColors()
        {
            return (favColors != null);
        }
    }
}
