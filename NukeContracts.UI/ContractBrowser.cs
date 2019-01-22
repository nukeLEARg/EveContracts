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
        private List<Contract> _contracts; //todo : save in dictionary<region, contracts>

        public ContractBrowser()
        {
            InitializeComponent();
            IDSearch.BuildItemList();
            _contractPanels = new List<ContractPanel>();
            _nuke = new NukeLogic();
            _nuke.ContractLoaded += ContractLoaded;
            _nuke.ContractsLoadingStarting += ContractsLoadingStarting;

            cbo_Region.DataSource = Enum.GetValues(typeof(Region));
            cbo_Region.Format += delegate (object sender, ListControlConvertEventArgs e)
            {
                e.Value = ((Region)e.Value).DisplayName();
            };
        }

        private void ContractLoaded(object sender, ContractEventArgs e)
        {
            if (pb_APIBar.InvokeRequired) pb_APIBar.BeginInvoke((Action)(() => ContractLoaded(sender, e)));
            else
            {
                Debug.WriteLine($"Received notification for contract[{e.ContractId}] loaded!");
                if (++pb_APIBar.Value < pb_APIBar.Maximum) lbl_progress.Text = $"loading {pb_APIBar.Maximum - pb_APIBar.Value} contracts...";
                else
                {
                    pb_APIBar.Value = 0;
                    pb_APIBar.Visible = false;
                    lbl_progress.Visible = false;
                    cbo_Region.Enabled = true;
                    btn_LoadRegion.Enabled = true;
                }
            }
        }

        private void ContractsLoadingStarting(object sender, ContractEventArgs e)
        {
            if (pb_APIBar.InvokeRequired) pb_APIBar.BeginInvoke((Action)(() => ContractLoaded(sender, e)));
            else
            {
                cbo_Region.Enabled = false;
                btn_LoadRegion.Enabled = false;

                lbl_progress.Visible = true;
                lbl_progress.Text = $"loading {e.LoadingContractsAmmount} contracts...";

                pb_APIBar.Visible = true;
                pb_APIBar.Value = 0;
                pb_APIBar.Maximum = e.LoadingContractsAmmount;
            }
        }

        private void Btn_LoadRegion_Click(object sender, EventArgs e)
        {
            Enum.TryParse(cbo_Region.SelectedValue.ToString(), out Region region);
            btn_PrevPage.Enabled = false;
            listPage = 0;

            #region Filter Building

            var testMax = Int32.MaxValue;
            var testMin = 0;
            Func<Contract, bool> filter = ((Contract c) => c.Price > testMin && c.Price < testMax);

            #endregion

            _contracts = _nuke.Contracts(region, filter);
            lbl_Pages.Text = $"Contracts: {_contracts.Count()}";
            btn_NextPage.Enabled = _contracts.Count() > listStep;
            BuildContractList();
        }

        #region todo : move to usercontrol

        private List<ContractPanel> _contractPanels;
        private int listPage = 0;
        private int listStep = 12;

        private void BuildContractList()
        {
            //todo : refactor into a user control, use flowlayout instead of calculating top
            pnl_ContractWindow.Controls.Clear();
            int top = 0;
            int height = 40;
            List<Contract> reducedContracts = _contracts.Skip(listPage * listStep).Take(listStep).ToList();
            _contracts.Skip(listPage * listStep).Take(listStep).ToList().ForEach(c => 
            {
                ContractPanel panelToAdd = new ContractPanel(c)
                {
                    Top = top,
                    Left = 0,
                    Height = height,
                    Width = 230
                };
                panelToAdd.Click += I_Click;
                foreach (Control cont in panelToAdd.Controls)
                {
                    cont.Click += C_Click;
                }
                pnl_ContractWindow.Controls.Add(panelToAdd);
                _contractPanels.Add(panelToAdd);
                top += height;
            });
        }

        void C_Click(object sender, EventArgs e)
        {
            Control cont = (Control)sender;
            I_Click(cont.Parent, e);
        }

        void I_Click(object sender, EventArgs e)
        {
            _contractPanels.ForEach(p => p.BackColor = SystemColors.Control);

            var panel = (ContractPanel)sender;
            panel.BackColor = Color.CadetBlue;
            pnl_InfoPane.Controls.Clear();
            pnl_InfoPane.Controls.Add(new ContractInfo(panel.Contract));
        }

        private void Btn_NextPage_Click(object sender, EventArgs e)
        {
            btn_PrevPage.Enabled = true;
            if (++listPage >= Math.Ceiling(_contracts.Count() / (double)listStep) - 1) btn_NextPage.Enabled = false;
            BuildContractList();
        }

        private void Btn_PrevPage_Click(object sender, EventArgs e)
        {
            btn_NextPage.Enabled = true;
            if (--listPage == 0) btn_PrevPage.Enabled = false;
            BuildContractList();
        }

        #endregion
    }
}
