using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBSRules
{
    class ActionSet
    {
        public Transition tran;
        public List<ActionSet> branches;

        public ActionSet(Transition tran)
        {
            this.tran = tran;
            branches = new List<ActionSet>();
        }
    }
}
