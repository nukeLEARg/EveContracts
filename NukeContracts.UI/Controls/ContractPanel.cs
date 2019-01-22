using NukeContracts.Business.Models.Contracts;
using System;
using System.IO;
using System.Windows.Forms;

namespace NukeContracts.UI.Controls
{
    public partial class ContractPanel : UserControl
    {
        public Contract Contract { get; set; }

        public ContractPanel(Contract contract)
        {
            InitializeComponent();
            Contract = contract;
            GenerateText(contract);
        }

        private void GenerateText(Contract contract)
        {
            //if (string.IsNullOrWhiteSpace(contract.Title)) contract.Title = "No Title"; #FIX THIS LATER
            if (string.IsNullOrWhiteSpace(contract.Title)) contract.Title = contract.ContractId.ToString();
            lb_ContractName.Text = contract.Title;
            lb_Amount.Text = $"{contract.Price:#,##0.00} ISK";
            String path = $"WindowIcons\\contracts.png";
            if (File.Exists(path)) pb_Icon.Load(path);
        }
    }
}
