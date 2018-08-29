using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeContracts.Business;
using NukeESI;

namespace NukeContracts.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tv_Main_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tv_MainView.SelectedNode.Parent == null)
            {

            }
            else
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // IDSearch itemSearch = new IDSearch();
            JitaExchange jita = new JitaExchange();
            jita.Pull();
            int x = 0;
            foreach(Contract contract in jita.Contracts)
            {
                if (contract.info.title == "")
                {
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.contract_id.ToString()));
                    foreach(ContractContents item in contract.contents)
                    {
                        //tv_MainView.Nodes[x].Nodes.Add(itemSearch.getName(item.type_id));
                        tv_MainView.Nodes[x].Nodes.Add(item.item_id.ToString());
                    }
                }
                else
                {
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.title));
                    foreach (ContractContents item in contract.contents)
                    {
                        //tv_MainView.Nodes[x].Nodes.Add(itemSearch.getName(item.type_id));
                        tv_MainView.Nodes[x].Nodes.Add(item.item_id.ToString());
                    }
                }
                x++;
            }
        }
        
    }
}
