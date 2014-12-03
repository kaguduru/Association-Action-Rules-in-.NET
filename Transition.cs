using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBSRules
{
    class Transition
    {
        public String beacon, from, to;
        public Transition(String beacon, String from, String to)
        {
            this.beacon = beacon;
            this.from = from;
            this.to = to;
        }
        public override string ToString()
        {
            return "("+beacon+","+from+"->"+to+")";
        }
    }
}
