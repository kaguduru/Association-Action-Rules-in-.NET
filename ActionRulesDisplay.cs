using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBSRules
{
    public partial class ActionRulesDisplay : Form
    {        
        List<String> res;
        Transition dec;
        public ActionRulesDisplay()
        {
            InitializeComponent();
        }

        private void ActionRulesDisplay_Load(object sender, EventArgs e)
        {

        }
        internal void loadResultData(List<String> res, Transition dec)
        {
            this.res = res;
            this.dec = dec;
            tb_results.Text = "";
            foreach(String result in res)
            {                
                tb_results.Text += result+"\r\n";
            }
        }
    }
}
