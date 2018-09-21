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
    public partial class ContractBrowser : Form
    {
        public ContractBrowser()
        {
            InitializeComponent();
            dd_region.SelectedIndex = 0;
        }
        
        private JitaExchange jita = new JitaExchange(0);

        private void tv_Main_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnl_InfoPane.Controls.Clear();
            if (tv_MainView.SelectedNode.Parent == null)
            {
                var contract = jita.Contracts.SingleOrDefault(Contract => Contract.info.contract_id.ToString() == tv_MainView.SelectedNode.Tag.ToString());
                pnl_InfoPane.Controls.Add(new ContractInfo(contract));
            }
            else
            {
                var contract = jita.Contracts.SingleOrDefault(Contract => Contract.info.contract_id.ToString() == tv_MainView.SelectedNode.Parent.Tag.ToString());
                int itemIndex = tv_MainView.SelectedNode.Index;
                pnl_InfoPane.Controls.Add(new ItemInfo(contract.contents[itemIndex]));
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dd_region.SelectedIndex != 0)
            {
                int region = 10000000 + dd_region.SelectedIndex;
                IDSearch itemSearch = new IDSearch();
                jita = new JitaExchange(region);
                jita.Pull();
                lb_Pages.Text = $"Pages: {jita.pages} Contracts: {jita.contracttotal}";
                int x = 0;
                foreach (Contract contract in jita.Contracts)
                {
                    if (contract.info.title == "")
                    {
                        tv_MainView.Nodes.Add(new TreeNode(contract.info.contract_id.ToString()));
                        tv_MainView.Nodes[tv_MainView.Nodes.Count - 1].Tag = contract.info.contract_id;
                        foreach (ContractContents item in contract.contents)
                        {
                            tv_MainView.Nodes[x].Nodes.Add(itemSearch.getName(item.type_id));
                        }
                    }
                    else
                    {
                        tv_MainView.Nodes.Add(new TreeNode(contract.info.title));
                        tv_MainView.Nodes[tv_MainView.Nodes.Count - 1].Tag = contract.info.contract_id;
                        foreach (ContractContents item in contract.contents)
                        {
                            tv_MainView.Nodes[x].Nodes.Add(itemSearch.getName(item.type_id));
                        }
                    }
                    x++;
                }
            }
        }
        
    }
}
