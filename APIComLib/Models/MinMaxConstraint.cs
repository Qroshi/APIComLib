using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models
{
    public class MinMaxConstraint
    {
        int minValue;
        int maxValue;
        public MinMaxConstraint(int min, int max) { this.minValue = min; this.maxValue = max;}
    }
}
