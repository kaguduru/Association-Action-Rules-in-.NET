using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBSRules
{
    public partial class Form1 : Form
    {
        DataTable table;
        RuleGenerator generator;
        public static int decNum=0;
        public static String decision = "Decision";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_broswe_Click(object sender, EventArgs e)
        {
            StreamReader myStream = null;
            generator = new RuleGenerator();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //Displaying a browse dialog for selecting the file
            openFileDialog1.InitialDirectory = "c:\\";
            //openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = new StreamReader(openFileDialog1.OpenFile())) != null)
                    {
                        txt_path.Text = openFileDialog1.FileName.ToString();
                        using (myStream)
                        {
                            table = generator.fetchRawData(myStream);
                        }
                        gv_Data.DataSource = table;
                        gv_Data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;                        
                    }
                    gv_Attributes.Columns.Add("typ", "Type");
                    gv_Attributes.Columns.Add("atr", "Attribute");
                    gv_Attributes.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(gv_Attributes_EditingControlShowing);
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        DataGridViewComboBoxCell comboCell = new DataGridViewComboBoxCell();
                        comboCell.DataSource = new List<String> { "Stable", "Flexible", "Decision", "Exclude" };
                        gv_Attributes.Rows.Add(new DataGridViewRow());
                        gv_Attributes.Rows[i].Cells[0] = comboCell;
                        gv_Attributes.Rows[i].Cells[1].Value = table.Columns[i].ColumnName;//header[i];
                    }
                    gv_Attributes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk.\nOriginal error: " + ex.Message);
                }                
            }            
        }
        private void gv_Attributes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            var comboBox = (DataGridViewComboBoxEditingControl)sender;
            int colNum = comboBox.EditingControlRowIndex;
            String tstr = "";
            string item = comboBox.Text;
            List<String> comboSource = new List<String>();
            if (item == "Decision")
            {
                decNum = colNum;
                for (int i = 0; i < gv_Attributes.Rows.Count; i++)
                {
                    if (i != colNum)
                    {
                        DataGridViewComboBoxCell tcell = (DataGridViewComboBoxCell)gv_Attributes.Rows[i].Cells[0];
                        if (tcell.Value == null)
                            tstr = "";
                        else
                            tstr = (tcell.Value.ToString());
                        if (!(tstr == "Decision"))
                        {

                            tcell.DataSource = new List<String> { "Stable", "Flexible", "Exclude" };
                            tcell.Value = tstr;
                        }
                    }
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (!(comboSource.Contains(table.Rows[i][colNum])))
                        comboSource.Add(table.Rows[i][colNum].ToString());
                }
                comboBox1.DataSource = comboSource;
                comboBox2.DataSource = new List<String>(comboSource);
            }
            else if(colNum == decNum)
            {
                for (int i = 0; i < gv_Attributes.Rows.Count; i++)
                {
                    if (i != colNum)
                    {
                        DataGridViewComboBoxCell tcell = (DataGridViewComboBoxCell)gv_Attributes.Rows[i].Cells[0];
                        if (tcell.Value == null)
                            tstr = "";
                        else
                            tstr = (tcell.Value.ToString());
                        if (!(tstr == "Decision"))
                        {

                            tcell.DataSource = new List<String> { "Stable", "Flexible", "Decision", "Exclude" };
                            tcell.Value = tstr;
                        }
                    }
                }
                comboBox1.DataSource = null;
                comboBox1.SelectedText = "";
                comboBox2.DataSource = null;
                comboBox2.SelectedText = "";
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int i = 0; i < gv_Attributes.Rows.Count; i++)
            {
                if (((DataGridViewComboBoxCell)(gv_Attributes.Rows[i].Cells[0])).Value == null)
                {
                    flag = 1;
                    break;
                }
            }
            if(comboBox1.SelectedValue!=null && comboBox2.SelectedValue!=null && 
                nud_Support.Value>0 && nud_Confidence.Value>0 && flag == 0)
            {
                Dictionary<String, List<String>> types = new Dictionary<string, List<string>>();
                ActionRulesDisplay resDisp;
                String decBeacon = "";
                foreach(DataGridViewRow row in gv_Attributes.Rows)
                {
                    String key = row.Cells[0].Value.ToString();
                    String val = row.Cells[1].Value.ToString().Trim();
                    List<String> temp = new List<String>();
                    if(key == decision)
                        decBeacon = val;
                    if (types.ContainsKey(key))
                    {
                        temp = types[key];
                        types.Remove(key);                       
                    }
                    temp.Add(val);
                    types.Add(key, temp);
                }
                generator.decision = new Transition(decBeacon,comboBox1.SelectedValue.ToString(),comboBox2.SelectedValue.ToString());
                generator.supp = Convert.ToDouble(nud_Support.Value);
                generator.conf = Convert.ToDouble(nud_Confidence.Value);
                generator.generateAtomics(types);
                resDisp = new ActionRulesDisplay();
                resDisp.loadResultData(generator.finalResult, generator.decision);
                resDisp.Show();
            }
            else
            {
                MessageBox.Show("Kindly make valid selections and try again.");
            }
        }
    }
}
