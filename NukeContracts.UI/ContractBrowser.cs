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
        private ContractExchange exchange = new ContractExchange(0);
        private IDSearch itemSearch;
        private int region;

        public ContractBrowser()
        {
            InitializeComponent();
            dd_region.DataSource = ContractExchange.regions;
            dd_region.DisplayMember = "Name";
            dd_region.ValueMember = "id";
            dd_region.SelectedIndex = 0;
        }

        private void tv_Main_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnl_InfoPane.Controls.Clear();
            if (tv_MainView.SelectedNode.Parent == null)
            {
                var contract = exchange.filteredContracts.SingleOrDefault(Contract => Contract.info.contract_id.ToString() == tv_MainView.SelectedNode.Tag.ToString());
                pnl_InfoPane.Controls.Add(new ContractInfo(contract, itemSearch));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tv_MainView.Nodes.Clear();
            if(itemSearch == null)
            {
                itemSearch = new IDSearch();
            }
            region = Convert.ToInt32(dd_region.SelectedValue);
            exchange = new ContractExchange(region);
            exchange.Pull();
            lb_Pages.Text = $"Pages: {exchange.pages} Contracts: {exchange.filteredContracts.Count}";
            foreach (Contract contract in exchange.filteredContracts)
            {
                if (contract.info.title == "")
                {
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.contract_id.ToString()));
                    tv_MainView.Nodes[tv_MainView.Nodes.Count - 1].Tag = contract.info.contract_id;
                }
                else
                {
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.title));
                    tv_MainView.Nodes[tv_MainView.Nodes.Count - 1].Tag = contract.info.contract_id;
                }
            }
        }
    }
}
