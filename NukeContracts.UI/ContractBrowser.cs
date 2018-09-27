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

namespace NukeContracts.UI
{
    public partial class ContractBrowser : Form
    {
        private ContractExchange exchange = new ContractExchange();
        private int selectedRegion;

        public ContractBrowser()
        {
            InitializeComponent();
            dd_region.DataSource = ContractExchange.regions;
            dd_region.DisplayMember = "Name";
            dd_region.ValueMember = "id";
            dd_region.SelectedIndex = 0;
            IDSearch.buildItemList();
        }

        private void tv_Main_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnl_InfoPane.Controls.Clear();
            Contract contract = exchange.filteredContracts[tv_MainView.SelectedNode.Index];
            pnl_InfoPane.Controls.Add(new ContractInfo(contract));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tv_MainView.Nodes.Clear();
            selectedRegion = Convert.ToInt32(dd_region.SelectedValue);
            exchange.region = selectedRegion;
            exchange.Pull();
            lb_Pages.Text = $"Contracts: {exchange.filteredContracts.Count}";
            foreach (Contract contract in exchange.filteredContracts)
            {
                if (contract.info.title == "")
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.contract_id.ToString()));
                else
                    tv_MainView.Nodes.Add(new TreeNode(contract.info.title));
            }
        }
    }
}
