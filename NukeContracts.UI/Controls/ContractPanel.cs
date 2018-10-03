using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NukeContracts.Business.Models.Contracts;
using System.IO;

namespace NukeContracts.UI.Controls
{
    public partial class ContractPanel : UserControl
    {
        public Contract contract { get; set; }

        public ContractPanel(Contract contract)
        {
            InitializeComponent();
            this.contract = contract;
            genText(contract);
        }

        private void genText(Contract contract)
        {
            lb_Amount.Text = $"{contract.Price:#,##0.00} ISK";
            lb_ContractName.Text = contract.Title;
            String path = $"WindowIcons\\contracts.png";
            if (File.Exists(path))
                pb_Icon.Load(path);
        }
    }
}
