using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIComLib.Models
{
    public class Effects
    {
        public static string getEffect(int id)
        {
            switch(id)
            {
                case 0: return "NONE"; break;
                case 1: return "FADE"; break;
                case 2: return "RGB"; break;
                case 3: return "POLICE"; break;
                case 4: return "RELAX"; break;
                case 5: return "STROBO"; break;
                case 6: return "BELL"; break;
                default: return "ERROR";
            }
        }
    }
}