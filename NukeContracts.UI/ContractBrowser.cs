using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NukeContracts.Business;
using NukeContracts.Business.Events;
using NukeContracts.Business.Extensions;
using NukeContracts.Business.Models.Contracts;
using NukeContracts.UI.Controls;
using Region = NukeContracts.Business.Enumerations.Region;

namespace NukeContracts.UI
{
    public partial class ContractBrowser : Form
    {
        private NukeLogic _nuke;
        private List<ContractPanel> _contractPanels;
        private List<Contract> _contracts;
        private int listPage = 0;
        private int listStep = 12;

        public ContractBrowser()
        {
            InitializeComponent();
            IDSearch.buildItemList();
            _contractPanels = new List<ContractPanel>();
            _nuke = new NukeLogic();
            _nuke.ContractLoaded += ContractLoaded;
            cbo_Region.DataSource = Enum.GetValues(typeof(Region));
            cbo_Region.Format += delegate (object sender, ListControlConvertEventArgs e)
            {
                e.Value = ((Region)e.Value).DisplayName();
            };
        }

        private void ContractLoaded(object sender, ContractLoadedEventArgs e)
        {
            if (pb_APIBar.InvokeRequired) pb_APIBar.BeginInvoke((Action)(() => ContractLoaded(sender, e)));
            else
            {
                Debug.WriteLine($"Received notification for contract[{e.ContractId}] loaded!");
                if (++pb_APIBar.Value != pb_APIBar.Maximum) lbl_progress.Text = $"loading {pb_APIBar.Maximum - pb_APIBar.Value} contracts...";
                else
                {
                    pb_APIBar.Visible = false;
                    lbl_progress.Visible = false;
                    cbo_Region.Enabled = true;
                    btn_LoadRegion.Enabled = true;
                }
            }
        }

        private void Btn_LoadRegion_Click(object sender, EventArgs e)
        {
            cbo_Region.Enabled = false;
            btn_LoadRegion.Enabled = false;
            btn_PrevPage.Enabled = false;
            listPage = 0;

            Enum.TryParse(cbo_Region.SelectedValue.ToString(), out Region region);
            var testMax = 150000000;
            var contracts = _nuke.Contracts(region, (Contract c) =>  c.Price > 500000 && c.Price < testMax);
            var allLoaded = !contracts.Any(c => !c.isLoaded);

            cbo_Region.Enabled = allLoaded;
            btn_LoadRegion.Enabled = allLoaded;
            pb_APIBar.Visible = !allLoaded;
            lbl_progress.Visible = !allLoaded;

            if (!allLoaded)
            {
                pb_APIBar.Value = 0;
                pb_APIBar.Maximum = contracts.Count();
                lbl_Pages.Text = $"Contracts: {contracts.Count()}";
                lbl_progress.Text = $"loading {contracts.Count()} contracts...";
            }

            btn_NextPage.Enabled = contracts.Count() > listStep;
            _contracts = contracts;
            BuildContractList();
        }

        private void BuildContractList()
        {
            pnl_ContractWindow.Controls.Clear();
            int contractCount = 0;
            int top = 0;
            int left = 0;
            int height = 40;
            int width = 230;
            List<Contract> reducedContracts = _contracts.Skip(listPage*listStep).Take(listStep).ToList();
            foreach (Contract contract in reducedContracts)
            {
                ContractPanel panelToAdd = new ContractPanel(contract)
                {
                    Top = top,
                    Left = left,
                    Height = height,
                    Width = width
                };
                panelToAdd.Click += i_Click;
                foreach (Control cont in panelToAdd.Controls)
                {
                    cont.Click += c_Click;
                }
                pnl_ContractWindow.Controls.Add(panelToAdd);
                _contractPanels.Add(panelToAdd);
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
            foreach (ContractPanel otherPanel in _contractPanels)
            {
                otherPanel.BackColor = SystemColors.Control;
            }
            ContractPanel contract = (ContractPanel)sender;
            contract.BackColor = Color.CadetBlue;
            pnl_InfoPane.Controls.Add(new ContractInfo(contract.contract));
        }

        private void btn_NextPage_Click(object sender, EventArgs e)
        {
            btn_PrevPage.Enabled = true;
            if (++listPage >= Math.Ceiling(_contracts.Count() / (double)listStep) - 1)btn_NextPage.Enabled = false;
            BuildContractList();
        }

        private void btn_PrevPage_Click(object sender, EventArgs e)
        {
            btn_NextPage.Enabled = true;
            if (--listPage == 0) btn_PrevPage.Enabled = false;
            BuildContractList();
        }
    }
}
