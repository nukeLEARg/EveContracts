using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NukeContracts.Business;
using NukeContracts.Business.Models.Contracts;
using NukeContracts.UI.Controls;
using EveRegion = NukeContracts.Business.Enumerations.Region;

namespace NukeContracts.UI
{
    public partial class ContractBrowser : Form
    {
        private NukeLogic nuke = new NukeLogic();
        private List<ContractPanel> ContractPanels = new List<ContractPanel>();

        public ContractBrowser()
        {
            IDSearch.buildItemList();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var contracts = nuke.Contracts(EveRegion.TheSpire);
            lb_Pages.Text = $"Contracts: {contracts.Count()}";
            buildContractList(contracts);
        }

        private void buildContractList(List<Contract> contracts)
        {
            pnl_ContractWindow.Controls.Clear();
            int contractCount = 0;
            int top = 0;
            int left = 0;
            int height = 40;
            int width = 230;
            foreach (Contract contract in contracts)
            {
                ContractPanel panelToAdd = new ContractPanel(contract);
                panelToAdd.Top = top;
                panelToAdd.Left = left;
                panelToAdd.Height = height;
                panelToAdd.Width = width;
                panelToAdd.Click += i_Click;
                foreach (Control cont in panelToAdd.Controls)
                {
                    cont.Click += c_Click;
                }
                pnl_ContractWindow.Controls.Add(panelToAdd);
                ContractPanels.Add(panelToAdd);
                top += height;
                contractCount++;
            }
        }

        void c_Click(object sender, EventArgs e)
        {
            Control cont = (Control)sender;
            i_Click(cont.Parent, e);
        }

        void i_Click(object sender, EventArgs e)
        {
            pnl_InfoPane.Controls.Clear();
            foreach (ContractPanel otherPanel in ContractPanels)
            {
                otherPanel.BackColor = SystemColors.Control;
            }
            ContractPanel contract = (ContractPanel)sender;
            contract.BackColor = Color.CadetBlue;
            pnl_InfoPane.Controls.Add(new ContractInfo(contract.contract));
        }
    }
}
