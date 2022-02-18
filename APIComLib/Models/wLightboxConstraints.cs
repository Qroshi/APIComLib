using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models
{
    public class wLightboxConstraints
    {
        public int colorFadeMin { get;} = 25;
        public int colorFadeMax { get; } = 3600000;
        public int effectFadeMin { get; } = 25;
        public int effectFadeMax { get; } = 3600000;
        public int effectStepMin { get; } = 25;
        public int effectStepMax { get; } = 3600000;

        public int color1ChannelLength { get; } = 2;
        public int color4ChannelLength { get; } = 8;
        public int color5ChannelLength { get; } = 10;

        public int effectIDMin { get; } = 0;
        public int effectIDMax { get; } = 10;
    }
}
