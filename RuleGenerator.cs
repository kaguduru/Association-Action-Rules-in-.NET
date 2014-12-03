using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBSRules
{
    class RuleGenerator
    {
        #region Class Attributes
        public DataTable table { get; set; }
        public String[] header { get; set; }
        public Transition decision { get; set; }
        public double supp { get; set; }
        public double conf { get; set; }
        public double tsup, tconf;
        public Dictionary<String, List<Transition>> atomics;
        public List<String> keys;
        public Dictionary<Transition, ActionSet> trie;
        public List<String> finalResult;
        public static String flex = "Flexible";
        public static String stab = "Stable";
        public static String excl = "Exclude";
        public static String dec = "Decision";
        public static String noTran = "NoTransition";
        #endregion

        public RuleGenerator()
        {
            atomics = new Dictionary<string,List<Transition>>();
            keys = new List<string>();
            trie = new Dictionary<Transition, ActionSet>();
            finalResult = new List<string>();
            supp = conf = tsup = tconf = 0.0;
        }

        public DataTable fetchRawData(StreamReader reader)
        {
            String line = "";
            table = new DataTable();
            using (reader)
            {                
                if (!(line = reader.ReadLine()).Equals(null))
                {
                    header = line.Split(',');
                    foreach (String head in header)
                    {
                        table.Columns.Add(head, typeof(String));
                    }
                    while ((line = reader.ReadLine()) != null)
                    {
                        DataRow nextRow = table.NewRow();
                        String[] splitLine = line.Split(',');
                        for (int i = 0; i < header.Length; i++)
                        {
                            nextRow[header[i]] = splitLine[i];
                        }
                        table.Rows.Add(nextRow);
                    }                    
                }
            }
            return table;
        }

        public void generateAtomics(Dictionary<String, List<String>> types)
        {           
            Dictionary<String, List<String>> elements = new Dictionary<string,List<String>>();
            //getting the distinct elements in each column
            foreach(String str in header)
            {
                elements.Add(str, (from DataRow dr in table.Rows
                                   select (string)dr[str]).Distinct().ToList<String>());
            }

            //generating the atomic action sets
            foreach(String key in types.Keys)
            {                
                foreach(String attr in types[key])
                {
                    List<Transition> atom = new List<Transition>();
                    if(key == flex)
                        foreach(String el in elements[attr])
                            foreach (String els in elements[attr])
                            {
                                Transition t = new Transition(attr, el, els);
                                List<Transition> temp = new List<Transition>();
                                temp.Add(t);
                                checkSuppConf(temp);
                                if (tsup >= supp)
                                {
                                    atom.Add(t);
                                    if(tconf >= conf)
                                    {
                                        String res = generateResult(temp, tsup, tconf);
                                        if (res != noTran)
                                            finalResult.Add(res);
                                    }
                                }
                            }
                    else if(key == stab)
                        foreach (String el in elements[attr])
                        {
                            Transition t = new Transition(attr, el, el);
                            List<Transition> temp = new List<Transition>();
                            temp.Add(t);
                            checkSuppConf(temp);
                            if (tsup >= supp)
                            {
                                atom.Add(t);                                
                            }
                        }
                    if(atom.Count>0)
                        atomics.Add(attr, atom);
                }
            }

            //storing the sorted list of keys
            keys = atomics.Keys.ToList<String>();
            keys.Sort();

            //Seeding the actionset generator with atomics
            foreach(String key in keys)
            {
                foreach(Transition t in atomics[key])
                {
                    ActionSet axn = new ActionSet(t);
                    List<Transition> seq = new List<Transition>();
                    seq.Add(t);
                    trie.Add(t, findActionSets(axn, seq));
                }
            }
        }

        public ActionSet findActionSets(ActionSet axn, List<Transition> seq)
        {           
            //following code runs for internal nodes
            if (axn.branches.Count > 0)
            {
                for (int i = 0; i < axn.branches.Count; i++)
                {
                    seq.Add(axn.branches[i].tran);
                    axn.branches[i] = findActionSets(axn.branches[i], seq);
                }
                return axn;
            }
            else
            {
                //following code runs for leaf nodes
                int index = keys.IndexOf(axn.tran.beacon) + 1;
                for (int i = index; i < keys.Count(); i++)
                {
                    foreach (Transition t in atomics[keys[i]])
                    {
                        seq.Add(t);
                        checkSuppConf(seq);
                        if (tsup >= supp)
                        {
                            if (tconf >= conf)
                            {
                                String res = generateResult(seq, tsup, tconf);
                                if (res != noTran)
                                    finalResult.Add(res);
                            }
                            axn.branches.Add(new ActionSet(t));
                        }
                        seq.RemoveAt(seq.Count - 1);
                    }
                }
                if ((index + 1) < keys.Count)
                    return findActionSets(axn, seq);
                return axn;
            }
        }

        public void checkSuppConf(List<Transition> seq)
        {
            double lhsPre = 0, lhsPost = 0, preCount = 0, postCount = 0;
            List<DataRow> pre = (from DataRow dr in table.Rows select dr).ToList<DataRow>();
            List<DataRow> post = (from DataRow dr in table.Rows select dr).ToList<DataRow>();
            foreach(Transition tran in seq)
            {                
                pre = (pre.Where(dr => (string)dr[tran.beacon] == tran.from)).ToList<DataRow>();
                post = (post.Where(dr => (string)dr[tran.beacon] == tran.to)).ToList<DataRow>();
            }
            lhsPre = pre.Count();
            lhsPost = post.Count();           
            pre = (pre.Where(dr => (string)dr[decision.beacon] == decision.from)).ToList<DataRow>();
            post = (post.Where(dr => (string)dr[decision.beacon] == decision.to)).ToList<DataRow>();
            preCount = pre.Count();
            postCount = post.Count();
            tsup = Math.Min(preCount, postCount);
            tconf = 100 * ((preCount / lhsPre)*(postCount / lhsPost));
            //if (tsup >= supp && tconf >= conf)
            //    return true;
            //else
            //    return false;
        }

        public String generateResult(List<Transition> seq, double sup, double conf)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach(Transition tr in seq)
            {
                if (tr.from == tr.to)
                    count++;
                sb.Append(tr.ToString());
            }
            if (count == seq.Count)
                return noTran;
            sb.Append(" => "+decision.ToString());
            sb.Append("; Support: "+sup+"; confidence: "+conf);
            return sb.ToString();
        }
    }
}
