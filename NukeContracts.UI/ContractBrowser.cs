using System;
using System.Linq;
using System.Windows.Forms;
using NukeContracts.Business;
using NukeContracts.Business.Models.Contracts;
using EveRegion = NukeContracts.Business.Enumerations.Region;



namespace NukeContracts.UI
{
    public partial class ContractBrowser : Form
    {
        //private NukeLogic nuke = new NukeLogic();

        public ContractBrowser()
        {
            InitializeComponent();
        }

        private void tv_Main_AfterSelect(object sender, TreeViewEventArgs e)
        {   /*
            TODO: REFACTOR
            pnl_InfoPane.Controls.Clear();
            Contract contract = nuke.filteredContracts[tv_MainView.SelectedNode.Index];
            pnl_InfoPane.Controls.Add(new ContractInfo(contract));
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tv_MainView.Nodes.Clear();
            var nuke = new NukeLogic();
            var contracts = nuke.Contracts(EveRegion.TheSpire);
            lb_Pages.Text = $"Contracts: {contracts.Count()}";
            foreach (Contract contract in contracts)
            {
                if (contract.Title == "")
                    tv_MainView.Nodes.Add(new TreeNode(contract.ContractId.ToString()));
                else
                    tv_MainView.Nodes.Add(new TreeNode(contract.Title));
            }
            pnl_InfoPane.Controls.Add(new ContractInfo(contracts.FirstOrDefault()));
        }
    }
}
